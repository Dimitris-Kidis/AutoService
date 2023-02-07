using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Messages.CreateNewMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IAutoServiceRepository<Message> _msgRepository;
        public CreateMessageCommandHandler(IAutoServiceRepository<Message> msgRepository)
        {
            _msgRepository = msgRepository;
        }
        public Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var newMsg = new Message
            {
                Sender = request.Sender,
                Receiver = request.Receiver,
                Text = request.Text,
                Seen = false
            };

            _msgRepository.Add(newMsg);
            _msgRepository.Save();

            var resultId = newMsg.Id;
            return Task.FromResult(resultId);
        }
    }
}
