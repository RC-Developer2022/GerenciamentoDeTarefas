using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Tarefas.infrastructure.Interfaces;
using Tarefas.infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Tarefas.infrastructure;

public static class InjectionInfrastructure
{
    public static IServiceCollection AddCoreDependecyInfra(this IServiceCollection services) 
    {
        services.AddScoped<IGeralPersistence , GeralPersistence>();
        services.AddScoped<IPersonPersistence , PersonPersistence>();

        return services;
    }

    public static IServiceCollection AddCoreDbContext(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<TasksDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ,
             b => b.MigrationsAssembly(typeof(TasksDbContext).Assembly.FullName))
        );
        
        return services;
    }
}
