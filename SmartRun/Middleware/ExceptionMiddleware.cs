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
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            if (_hostEnvironment.IsDevelopment())
            {
                var response = new ApiException(
                    statusCode: context.Response.StatusCode.ToString(),
                    message: ex.Message,
                    description: ex.StackTrace.ToString());

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
            else
            {
                var response = new ApiException(
                statusCode: context.Response.StatusCode.ToString(),
                message: ex.Message,
                description: "Internal Server Error.");

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
