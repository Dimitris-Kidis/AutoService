using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetAllMasters
{
    public class GetAllMastersQueryHandler : IRequestHandler<GetAllMastersQuery, IEnumerable<MasterListItemDto>>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IMapper _mapper;

        public GetAllMastersQueryHandler(
            IUserRepository<User> userRepository,
            IAutoServiceRepository<Consultation> consRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _consRepository = consRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MasterListItemDto>> Handle(GetAllMastersQuery request, CancellationToken cancellationToken)
        {
            var cons = _consRepository.GetAll().ToList();

            var masters = _userRepository
                .FindBy(user => user.Role == true)
                .Select(user => new MasterListItemDto {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Avatar = user.Avatar,
                    PhoneNumber = user.PhoneNumber,
                    Experience = user.Experience,
                    Services = user.Services,
                    Description = user.Description
                })
                .ToList();

            foreach (var item in masters)
            {
                if (_consRepository.FindBy(con => con.MasterId == item.Id).Any())
                {
                    item.Rating = _consRepository.FindBy(con => con.MasterId == item.Id && con.Done == true).Select(con => con.Stars).Average();
                } else
                {
                    item.Rating = 0;
                }
            }

            return masters.Select(_mapper.Map<MasterListItemDto>);
        }
    }
}
