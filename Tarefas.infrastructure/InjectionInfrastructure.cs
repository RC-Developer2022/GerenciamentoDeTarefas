using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tarefas.infrastructure.Interfaces;
using Tarefas.infrastructure.Services;

namespace Tarefas.infrastructure;

public static class InjectionInfrastructure
{
    public static IServiceCollection AddCoreDependecyInfra(this IServiceCollection services) 
    {

        //services.AddDbContext<TasksDbContext>(options => options.UseSqlServer());
        services.AddScoped<IGeralPersistence , GeralPersistence>();
        services.AddScoped<IPersonPersistence , PersonPersistence>();

        return services;
    }
}
