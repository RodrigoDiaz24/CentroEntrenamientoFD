using CentroEntrenamientoFD.Application.Interfaces;
using CentroEntrenamientoFD.Application.Repositories.Interfaces;
using CentroEntrenamientoFD.Application.Services;
using CentroEntrenamientoFD.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CentroEntrenamientoFD.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            string jwtKey)
        {
            // Application
            services.AddScoped<RoutineService>();
            services.AddScoped<AuthService>();

            // Infrastructure - Repositorios
            services.AddScoped<IClientRoutineRepository, ClientRoutineRepository>();
            services.AddScoped<IRoutineExecutionRepository, RoutineExecutionRepository>();

            // Infrastructure - Repositorios de usuarios
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
