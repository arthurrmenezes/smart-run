using SmartRun.Application;
using SmartRun.Application.Services.TrainingContext;
using SmartRun.Application.Services.TrainingContext.Interfaces;
using SmartRun.Infrastructure;

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

        builder.Services.AddScoped<ITrainingService, TrainingService>();
        builder.Services.ApplyApplicationDependenciesConfiguration();

        #endregion

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
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