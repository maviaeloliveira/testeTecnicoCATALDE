

using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CrossCutting.Ioc
{
    public static class DependencyInjectionAPI
    {
        private static string _CORSPoliceName = "API-Modelo";
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole().AddDebug(); });
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                     )
                 .EnableSensitiveDataLogging(true)
                   .UseLoggerFactory(loggerFactory)
                 );


            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: _CORSPoliceName,
                    builder =>
                    {
                        builder.AllowAnyMethod()
                               .AllowAnyHeader()
                               .WithOrigins(configuration.GetSection("CORS").GetChildren().Select(c => c.Value).ToArray());
                    }
                );
            });


            return services;
        }        
    }
}
