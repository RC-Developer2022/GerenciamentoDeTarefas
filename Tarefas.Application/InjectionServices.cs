﻿using Microsoft.Extensions.DependencyInjection;
using Tarefas.Application.Interfaces;
using Tarefas.Application.Services;

namespace Tarefas.Application;

public static class InjectionServices
{
    public static IServiceCollection AddCoreDependecyServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IPersonServices , PersonServices>();

        return services;
    }

}
