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

namespace Query.Messages.GetAllSeenMessages
{
    public class GetAllSeenMessagesQueryHandler : IRequestHandler<GetAllSeenMessagesQuery, IEnumerable<MessageDto>>
    {
        private readonly IAutoServiceRepository<Message> _msgsRepository;
        private readonly IMapper _mapper;

        public GetAllSeenMessagesQueryHandler(
            IAutoServiceRepository<Message> msgsRepository,
            IMapper mapper)
        {
            _msgsRepository = msgsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> Handle(GetAllSeenMessagesQuery request, CancellationToken cancellationToken)
        {
            var msgs = _msgsRepository
                .FindBy(msg => ((msg.Sender == request.Sender && msg.Receiver == request.Receiver) || (msg.Sender == request.Receiver && msg.Receiver == request.Sender)) && msg.Seen == true)
                .Select(msg => new MessageDto
                {
                    SenderId = msg.Sender,
                    ReceiverId = msg.Receiver,
                    Text = msg.Text,
                    DateTime = msg.CreatedAt
                })
                .ToList();

            return msgs.Select(_mapper.Map<MessageDto>);
        }
    }
}
