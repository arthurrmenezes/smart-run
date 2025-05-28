using Microsoft.Extensions.DependencyInjection;
using SmartRun.Application.Services.TrainingContext;
using SmartRun.Application.Services.TrainingContext.Interfaces;

namespace SmartRun.Application;

public static class DependencyInjection
{
    public static IServiceCollection ApplyApplicationDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITrainingService, TrainingService>();

        return serviceCollection;
    }
}
