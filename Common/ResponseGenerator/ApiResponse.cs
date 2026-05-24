using JobPortalAPI.Common.Constant;
public class ApiResponse<T>
{
    public bool IsError { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public ApiResponse()
    {
    }

    public ApiResponse(bool isError, string code, string message, T? data = default)
    {
        IsError = isError;
        Code = code;
        Message = message;
        Data = data!;
    }
}

public static class ResponseGenerator
{
    public static ApiResponse<T?> Generate<T>(string? message = null, string? code = null, bool isError = false, T? data = default)
    {
        return new ApiResponse<T?>
        {
            IsError = isError,
            Code = code ?? (isError ? ResponseConstants.CODE_ERROR : ResponseConstants.CODE_SUCCESS),
            Message = message ?? (isError ? ResponseConstants.MSG_ERROR : ResponseConstants.MSG_SUCCESS),
            Data = data
        };
    }

    public static ApiResponse<T?> Success<T>(T? data = default, string? message = null)
    {
        return Generate(message: message ?? ResponseConstants.MSG_SUCCESS, code: ResponseConstants.CODE_SUCCESS, isError: false, data: data);
    }

    public static ApiResponse<T?> Error<T>(string? message = null, string? code = null, T? data = default)
    {
        return Generate(message: message ?? ResponseConstants.MSG_ERROR, code: code ?? ResponseConstants.CODE_ERROR, isError: true, data: data);
    }

    public static ApiResponse<T?> BadRequest<T>(string? message = null, T? data = default)
    {
        return Generate(message: message ?? ResponseConstants.MSG_BAD_REQUEST, code: ResponseConstants.CODE_BAD_REQUEST, isError: true, data: data);
    }

    public static ApiResponse<T?> NotFound<T>(string? message = null, T? data = default)
    {
        return Generate(
            message: message ?? ResponseConstants.MSG_NOT_FOUND,
            code: ResponseConstants.CODE_NOT_FOUND,
            isError: true,
            data: data
        );
    }

    public static ApiResponse<T?> Unauthorized<T>(string? message = null, T? data = default)
    {
        return Generate(message: message ?? ResponseConstants.MSG_UNAUTHORIZED, code: ResponseConstants.CODE_UNAUTHORIZED, isError: true, data: data);
    }
}