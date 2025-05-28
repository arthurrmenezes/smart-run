using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartRun.Infrastructure.Data;
using SmartRun.Infrastructure.Data.Repositories;
using SmartRun.Infrastructure.Data.Repositories.Interfaces;

namespace SmartRun.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ApplyInfrastructureDependenciesConfiguration(
        this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        #region DataBase Configuration

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        serviceCollection.AddDbContext<DataContext>(options =>
        options.UseSqlServer(connectionString, 
        sqlOption => sqlOption.MigrationsAssembly("SmartRun.Infrastructure")));

        #endregion

        serviceCollection.AddScoped<ITrainingRepository, TrainingRepository>();

        return serviceCollection;
    }
}
