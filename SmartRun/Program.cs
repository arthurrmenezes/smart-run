using SmartRun.Application;
using SmartRun.Infrastructure;
using SmartRun.WebApi.Middleware;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Authentication with JWT Bearer Configuration

        #endregion

        #region Infrastructure Dependencies Configuration

        builder.Services.ApplyInfrastructureDependenciesConfiguration(builder.Configuration);

        #endregion

        #region Application Dependencies Configuration

        builder.Services.ApplyApplicationDependenciesConfiguration();

        #endregion

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        #region Middleware Configuration

        app.UseMiddleware<ExceptionMiddleware>();

        #endregion

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Run();
    }
}