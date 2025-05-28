using Microsoft.Extensions.DependencyInjection;
using SmartRun.Infrastructure.Data.Repositories;
using SmartRun.Infrastructure.Data.Repositories.Interfaces;

namespace SmartRun.Application;

public static class DependencyInjection
{
    public static IServiceCollection ApplyApplicationDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITrainingRepository, TrainingRepository>();

        return serviceCollection;
    }
}
