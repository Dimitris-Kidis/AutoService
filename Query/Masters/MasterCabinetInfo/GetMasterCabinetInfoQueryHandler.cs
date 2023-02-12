using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using Query.Masters.GetMasterInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.MasterCabinetInfo
{
    public class GetMasterCabinetInfoHandler : IRequestHandler<GetMasterCabinetInfoQuery, MasterInfoDto>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IMapper _mapper;

        public GetMasterCabinetInfoHandler(
            IUserRepository<User> userRepository,
            IAutoServiceRepository<Consultation> consRepository,
            IMapper mapper)
        {
            _consRepository = consRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<MasterInfoDto> Handle(GetMasterCabinetInfoQuery request, CancellationToken cancellationToken)
        {

            var master = _userRepository.FindBy(user => user.Id == request.MasterId).FirstOrDefault();

            var masterInfo = new MasterInfoDto
            {
                Email = master.Email,
                FirstName = master.FirstName,
                LastName = master.LastName,
                PhoneNumber = master.PhoneNumber,
                Age = master.Age,
                Avatar = master.Avatar,
                Experience = master.Experience,
                Services = master.Services,
                Description = master.Description
            };

            return _mapper.Map<MasterInfoDto>(masterInfo);
        }
    }
}
