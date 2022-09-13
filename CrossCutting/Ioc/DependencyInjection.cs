using Application.Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Domain.Interfaces.Service;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CrossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IOcorrenciaService, OcorrenciaService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
