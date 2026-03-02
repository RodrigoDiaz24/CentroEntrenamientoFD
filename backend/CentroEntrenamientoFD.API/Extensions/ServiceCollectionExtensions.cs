using CentroEntrenamientoFD.Application.Interfaces;
using CentroEntrenamientoFD.Application.Repositories.Interfaces;
using CentroEntrenamientoFD.Application.Services;
using CentroEntrenamientoFD.Infrastructure.Auth;
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

            // Infrastructure - Repositorios
            services.AddScoped<IRutinaRepository, RutinaInMemoryRepository>();

            // Infrastructure - Auth
            services.AddScoped<IAuthService>(sp => new AuthService(jwtKey));

            return services;
        }
    }
}
