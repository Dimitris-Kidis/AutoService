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

namespace Query.Masters.GetMasterHistory
{
    public class GetMasterHistoryQueryHandler : IRequestHandler<GetMasterHistoryQuery, IEnumerable<MasterHistoryDto>>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IAutoServiceRepository<Car> _carsRepository;
        private readonly IMapper _mapper;

        public GetMasterHistoryQueryHandler(
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

        public async Task<IEnumerable<MasterHistoryDto>> Handle(GetMasterHistoryQuery request, CancellationToken cancellationToken)
        {
            var currentUserCons = _consRepository.FindBy(cons => cons.MasterId == request.MasterId).ToList();

            var cars = _carsRepository.GetAll().ToList();


            var ids = _consRepository.FindBy(cons => cons.MasterId == request.MasterId).Select(x => x.ClientId).ToList();
            var clients = _userRepository.FindBy(cons => ids.Contains(cons.Id)).ToList();

            var historyRows = (from con in currentUserCons
                               join client in clients on con.ClientId equals client.Id
                               join car in cars on con.CarId equals car.Id
                               select new MasterHistoryDto
                               {
                                   CarInfo = car.Brand + ", " + car.Model + $" ({car.Year + " " + car.Engine})",
                                   Services = car.Services,
                                   ClientName = client.FirstName + " " + client.LastName,
                                   ClientAvatar = client.Avatar,
                                   Done = con.Done,
                                   Stars = con.Done == false ? 0 : con.Stars
                               }).ToList();


            return historyRows.Select(_mapper.Map<MasterHistoryDto>);
        }
    }
}
