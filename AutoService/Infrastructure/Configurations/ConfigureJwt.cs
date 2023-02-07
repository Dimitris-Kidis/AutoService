//using TYPO.Identity;

using AutoService.Identity;

namespace AutoService.Infrastructure.Configurations
{
    public static class ConfigureJwt
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            services.AddScoped<JwtHandler>();
            services.AddJwtAuthentication();
            return services;
        }
    }
}
