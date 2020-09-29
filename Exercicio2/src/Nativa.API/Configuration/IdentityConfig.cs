using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Nativa.API.Data;

namespace Nativa.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection IdetityConfiguration(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
