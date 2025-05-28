namespace SmartRun.WebApi.Exceptions;

public class ApiException
{
    public string StatusCode { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }

    public ApiException(string statusCode, string message, string description)
    {
        StatusCode = statusCode;
        Message = message;
        Description = description;
    }
}
