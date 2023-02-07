using AutoMapper;

namespace AutoService.Infrastructure.Configurations
{
    public static class ConfigureMapper
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Program).Assembly, typeof(Query.Masters.GetAllMasters.GetAllMastersQuery).Assembly);
            services.AddAutoMapper(typeof(Program).Assembly, typeof(Command.Auth.Registration.RegistrationCommand).Assembly);
            return services;
        }
    }
}
