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

namespace Query.Client.GetClientsForChat
{
    public class GetClientsForChatQueryHandler : IRequestHandler<GetClientsForChatQuery, IEnumerable<ClientsForChatDto>>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IAutoServiceRepository<Message> _msgsRepository;
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        private readonly IAutoServiceRepository<Car> _carsRepository;
        private readonly IMapper _mapper;

        public GetClientsForChatQueryHandler(
            IUserRepository<User> userRepository,
            IAutoServiceRepository<Consultation> consRepository,
            IAutoServiceRepository<Message> msgsRepository,
            IAutoServiceRepository<Car> carsRepository,
            IMapper mapper)
        {
            _msgsRepository = msgsRepository;
            _carsRepository = carsRepository;
            _consRepository = consRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientsForChatDto>> Handle(GetClientsForChatQuery request, CancellationToken cancellationToken)
        {
            var activeCons = _consRepository.FindBy(cons => cons.MasterId == request.MasterId && cons.Done == false).ToList();

            var cars = _carsRepository.GetAll().ToList();

            var activeClients = activeCons.Select(con => con.ClientId).ToList();

            var clients = _userRepository.FindBy(cons => activeClients.Contains(cons.Id)).ToList();

            var msgs = _msgsRepository.FindBy(msg => msg.Receiver == request.MasterId).ToList();

            var alClients = (from con in activeCons
                             join client in clients on con.ClientId equals client.Id
                             join car in cars on con.CarId equals car.Id
                             select new ClientsForChatDto
                             {
                                 Id = client.Id,
                                 CarInfo = car.Brand + ", " + car.Model + $" ({car.Year + ", " + car.Engine})",
                                 FullName = client.FirstName + " " + client.LastName,
                                 Avatar = client.Avatar,
                                 PhoneNumber = client.PhoneNumber,
                                 Email = client.Email,
                                 HasNewMessage = msgs.Where(msg => msg.Sender == client.Id && msg.Receiver == request.MasterId && msg.Seen == false).Count() == 0 ? false : true
                             }).ToList();


            return alClients.Select(_mapper.Map<ClientsForChatDto>);
        }
    }
}
