namespace JobPortalAPI.DTOs;

public class Response
{
    public object? Data { get; set; }
    public bool Error_status { get; set; }
    public string? Message { get; set; }
    public int? Code { get; set; }
}