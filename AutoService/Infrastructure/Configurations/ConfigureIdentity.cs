using ApplicationCore.Domain;
using ApplicationCore.Domain.Entities;
using AutoService.Identity;
using Microsoft.AspNetCore.Identity;

namespace AutoService.Infrastructure.Configurations
{

    public static class ConfigureIdentity
    {
        public static IdentityBuilder AddIdentityConfiguration(this IServiceCollection services) =>
            services.AddIdentity<User, Role>(options =>
                {
                    options.User.RequireUniqueEmail = false;
                })
                .AddEntityFrameworkStores<AutoServiceDbContext>()
                .AddDefaultTokenProviders();
    }
}
