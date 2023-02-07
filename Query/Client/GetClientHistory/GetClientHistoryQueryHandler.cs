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

namespace Query.Client.GetClientHistory
{
    public class GetClientHistoryQueryHandler : IRequestHandler<GetClientHistoryQuery, IEnumerable<ClientHistoryDto>>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IAutoServiceRepository<Car> _carsRepository;
        private readonly IMapper _mapper;

        public GetClientHistoryQueryHandler(
            IUserRepository<User> userRepository,
            IAutoServiceRepository<Consultation> consRepository,
            IAutoServiceRepository<Car> carsRepository,
            IMapper mapper)
        {
            _carsRepository = carsRepository;
            _consRepository = consRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientHistoryDto>> Handle(GetClientHistoryQuery request, CancellationToken cancellationToken)
        {
            var currentUserCons = _consRepository.FindBy(cons => cons.ClientId == request.ClientId).ToList();

            var cars = _carsRepository.FindBy(car => car.ClientId == request.ClientId).ToList();


            var ids = _consRepository.FindBy(cons => cons.ClientId == request.ClientId).Select(x => x.MasterId).ToList();
            var masters = _userRepository.FindBy(cons => ids.Contains(cons.Id)).ToList();

            var historyRows = (from con in currentUserCons
                           join master in masters on con.MasterId equals master.Id
                           join car in cars on con.CarId equals car.Id
                           select new ClientHistoryDto
                           {
                               CarInfo = car.Brand + ", " + car.Model + $" ({car.Year + " " + car.Engine})",
                               Services = car.Services,
                               MasterName = master.FirstName + " " + master.LastName,
                               MasterAvatar = master.Avatar,
                               Done = con.Done,
                               Stars = con.Done == false ? 0 : con.Stars
                           }).ToList();


            return historyRows.Select(_mapper.Map<ClientHistoryDto>);
        }
    }
}
