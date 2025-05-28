using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartRun.Infrastructure.Data;

namespace SmartRun.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ApplyInfrastructureDependenciesConfiguration(
        this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        serviceCollection.AddDbContext<DataContext>(options =>
        options.UseSqlServer(connectionString, 
        sqlOption => sqlOption.MigrationsAssembly("SmartRun.Infrastructure")));

        return serviceCollection;
    }
}
