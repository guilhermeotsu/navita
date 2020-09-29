using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nativa.API.Extensions;
using Nativa.Data.Repository;
using Navita.Core.Interfaces;
using Navita.Core.Notificacoes;
using Navita.Core.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nativa.API.Configuration
{
    public static class DepedenciesConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<IPatrimonioRepository, PatrimonioRepository>();
            services.AddScoped<IPatrimonioService, PatrimonioService>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IMarcaService, MarcaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<INotifier, Notificador>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
