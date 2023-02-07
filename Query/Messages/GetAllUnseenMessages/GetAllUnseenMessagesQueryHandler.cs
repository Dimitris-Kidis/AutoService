using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using AutoMapper;
using MediatR;
using Query.Messages.GetAllSeenMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Messages.GetAllUnseenMessages
{
    public class GetAllUnseenMessagesQueryHandler : IRequestHandler<GetAllUnseenMessagesQuery, IEnumerable<MessageDto>>
    {
        private readonly IAutoServiceRepository<Message> _msgsRepository;
        private readonly IMapper _mapper;

        public GetAllUnseenMessagesQueryHandler(
            IAutoServiceRepository<Message> msgsRepository,
            IMapper mapper)
        {
            _msgsRepository = msgsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> Handle(GetAllUnseenMessagesQuery request, CancellationToken cancellationToken)
        {
            var msgs = _msgsRepository
                .FindBy(msg => ((msg.Sender == request.Sender && msg.Receiver == request.Receiver) || (msg.Sender == request.Receiver && msg.Receiver == request.Sender)) && msg.Seen == false)
                .Select(msg => new MessageDto
                {
                    SenderId = msg.Sender,
                    ReceiverId = msg.Receiver,
                    Text = msg.Text,
                    DateTime = msg.CreatedAt
                })
                .ToList();

            var unseenMsgs = _msgsRepository
                .FindBy(msg => ((msg.Sender == request.Sender && msg.Receiver == request.Receiver) || (msg.Sender == request.Receiver && msg.Receiver == request.Sender)) && msg.Seen == false);

            foreach (var msg in unseenMsgs)
            {
                msg.Seen = true;
            }
            _msgsRepository.UpdateRange(unseenMsgs);
            _msgsRepository.Save();

            return msgs.Select(_mapper.Map<MessageDto>);
        }
    }
}
