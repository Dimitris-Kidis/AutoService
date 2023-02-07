using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Auth.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, int>
    {
        private readonly UserManager<User> _userManager;

        public RegistrationCommandHandler(
            UserManager<User> userManager
        )
        {
            _userManager = userManager;
        }
        public async Task<int> Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {

            User user = new User
            {
                Role = command.Role,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PhoneNumber = command.PhoneNumber,
                Age = command.Age,
                Avatar = "https://thumbs.dreamstime.com/b/default-avatar-profile-trendy-style-social-media-user-icon-187599373.jpg",
                Password = command.Password,
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = command.Email,
                UserName = command.Email,

                Experience = command.Experience != null ? command.Experience : null,
                Services = command.Services != null ? command.Services : null,
                Description = command.Description != null ? command.Description : null,
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return await Task.FromResult(-1);
            }

            var resultId = user.Id;

            return await Task.FromResult(resultId);
        }
    }
}
