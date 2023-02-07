using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Masters.UpdateMaster
{
    public class UpdateMasterCommandHandler : IRequestHandler<UpdateMasterCommand, int>
    {
        private readonly IUserRepository<User> _userRepository;
        public UpdateMasterCommandHandler(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<int> Handle(UpdateMasterCommand request, CancellationToken cancellationToken)
        {

            var user = _userRepository.FindBy(user => user.Id == request.UserId).FirstOrDefault();

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.Age = request.Age;
            user.Experience = request.Experience;
            user.Services = request.Services;
            user.Description = request.Description;


            _userRepository.Update(user);
            _userRepository.Save();






            return Task.FromResult(0);
        }
    }
}
