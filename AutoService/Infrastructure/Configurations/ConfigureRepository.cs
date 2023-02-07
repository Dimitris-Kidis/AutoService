using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using ApplicationCore.Services.Repository.UserRepository;


namespace AutoService.Infrastructure.Configurations
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUserRepository<User>), typeof(UserRepository));
            services.AddScoped(typeof(IAutoServiceRepository<>), typeof(AutoServiceRepository<>));
            return services;
        }

    }
}
