using System.Text.Json;
using JobPortalAPI.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Middlewares;

public class GlobalExeptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExeptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public GlobalExeptionMiddleware(RequestDelegate next, ILogger<GlobalExeptionMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);

        var response = context.Response;
        response.ContentType = "application/json";

        var errorResponse = new Response
        {
            Error_status = false,
            Message = "An error occurred while processing your request.",
            Code = StatusCodes.Status500InternalServerError
        };

        switch (ex)
        {
            case DbUpdateConcurrencyException:
                errorResponse.Message = "Data concurrency conflict occurred.";
                errorResponse.Code = StatusCodes.Status409Conflict;
                break;

            case DbUpdateException:
                errorResponse.Message = "Database error occurred.";
                errorResponse.Code = StatusCodes.Status500InternalServerError;
                break;

            case InvalidOperationException:
                errorResponse.Message = "Invalid operation requested.";
                errorResponse.Code = StatusCodes.Status400BadRequest;
                break;

            case UnauthorizedAccessException:
                errorResponse.Message = "You are not authorized to perform this action.";
                errorResponse.Code = StatusCodes.Status401Unauthorized;
                break;

            case KeyNotFoundException:
                errorResponse.Message = "Requested resource not found.";
                errorResponse.Code = StatusCodes.Status404NotFound;
                break;

            case SqlException sqlEx:
                errorResponse.Message = "Database connection error. Please try again later.";
                errorResponse.Code = StatusCodes.Status503ServiceUnavailable;
                _logger.LogError(sqlEx, "SQL Error: {Number}", sqlEx.Number);
                break;

            case HttpRequestException:
                errorResponse.Message = "Service communication error.";
                errorResponse.Code = StatusCodes.Status503ServiceUnavailable;
                break;

            default:
                if (_env.IsDevelopment())
                {
                    errorResponse.Message = ex.Message;
                    errorResponse.Data = ex.StackTrace;
                }
                break;
        }
        response.StatusCode = errorResponse.Code ?? StatusCodes.Status500InternalServerError;
        await response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}