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

namespace Query.Client.GetCurrentConsultation
{
    public class GetCurrentConsultationQueryHandler : IRequestHandler<GetCurrentConsultationQuery, CurrentConsultationDto>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IMapper _mapper;

        public GetCurrentConsultationQueryHandler(
            IUserRepository<User> userRepository,
            IAutoServiceRepository<Consultation> consRepository,
            IMapper mapper)
        {
            _consRepository = consRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CurrentConsultationDto> Handle(GetCurrentConsultationQuery request, CancellationToken cancellationToken)
        {

            if (request.Role == false)
            {
                var masterId = _consRepository.FindBy(cons => cons.ClientId == request.UserId && cons.Done == false).LastOrDefault().MasterId;

                var masterInfo = new CurrentConsultationDto
                {
                    UserId = masterId
                };

                return _mapper.Map<CurrentConsultationDto>(masterInfo);
            } else
            {
                var clientId = _consRepository.FindBy(cons => cons.MasterId == request.UserId && cons.Done == false).LastOrDefault().ClientId;

                var masterInfo = new CurrentConsultationDto
                {
                    UserId = clientId
                };

                return _mapper.Map<CurrentConsultationDto>(masterInfo);
            }
            
        }
    }
}
