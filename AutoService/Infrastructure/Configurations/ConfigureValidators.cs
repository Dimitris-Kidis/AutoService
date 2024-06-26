﻿//using FluentValidation.AspNetCore;

//using FluentValidation.AspNetCore;

using FluentValidation.AspNetCore;

namespace AutoService.Infrastructure.Configurations
{
    public static class ConfigureValidators
    {
        public static IMvcBuilder AddValidators(this IMvcBuilder services) =>
            services.AddFluentValidation(opt => opt.RegisterValidatorsFromAssembly(typeof(Command.Cars.CreateNewCar.CreateNewCarCommand).Assembly));
    }
}
