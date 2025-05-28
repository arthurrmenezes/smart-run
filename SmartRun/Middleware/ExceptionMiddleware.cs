using SmartRun.WebApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace SmartRun.WebApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;    
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _hostEnvironment;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment hostEnvironment)
    {
        _next = next;
        _logger = logger;
        _hostEnvironment = hostEnvironment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, ex);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ex);
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, HttpStatusCode httpStatusCode, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) httpStatusCode;

        var response = new ApiException(
            statusCode: ((int) httpStatusCode).ToString(),
            message: exception.Message,
            description: _hostEnvironment.IsDevelopment() ? exception.StackTrace!.ToString() : "Internal Server Error.");

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var json = JsonSerializer.Serialize(response, options);

        await context.Response.WriteAsync(json);
    }
}
