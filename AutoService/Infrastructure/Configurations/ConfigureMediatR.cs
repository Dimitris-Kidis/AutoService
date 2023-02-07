//using Command.Texts.CreateNewText;
//using Command.Users.CreateNewUser;
//using Command.Users.DeleteUserById;
//using FluentValidation;
//using Command.Notes.CreateNewNote;
//using MediatR;
//using Query.Teachers.GetAllStudentTeachersByStudentId;
//using Query.Users.GetAllUsers;

using Command.Auth.Registration;
using MediatR;
using Query.Masters.GetAllMasters;

namespace AutoService.Infrastructure.Configurations
{
    public static class ConfigureMediatR
    {
        public static IServiceCollection AddMediatRConfigs(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllMastersQueryHandler).Assembly);
            services.AddMediatR(typeof(RegistrationCommandHandler).Assembly);
            return services;
        }

    }
}
