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

namespace Query.Consultations.GetIsThereConsultation
{
    public class GetIsThereConsultationQueryHandler : IRequestHandler<GetIsThereConsultationQuery, IsThereConsultationDto>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IMapper _mapper;

        public GetIsThereConsultationQueryHandler(
            IUserRepository<User> userRepository,
            IAutoServiceRepository<Consultation> consRepository,
            IMapper mapper)
        {
            _consRepository = consRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IsThereConsultationDto> Handle(GetIsThereConsultationQuery request, CancellationToken cancellationToken)
        {
            if (request.Role == false)
            {
                var isThereConsultation = _consRepository.FindBy(cons => cons.ClientId == request.UserId && cons.Done == false).Count();

                var masterInfo = new IsThereConsultationDto
                {
                    IsThereConsultation = isThereConsultation >= 1 ? true : false
                };

                return _mapper.Map<IsThereConsultationDto>(masterInfo);
            } else
            {
                var isThereConsultation = _consRepository.FindBy(cons => cons.MasterId == request.UserId && cons.Done == false).Count();

                var masterInfo = new IsThereConsultationDto
                {
                    IsThereConsultation = isThereConsultation >= 1 ? true : false
                };

                return _mapper.Map<IsThereConsultationDto>(masterInfo);
            }
            
        }
    }
}
