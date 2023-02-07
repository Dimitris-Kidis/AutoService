using MediatR;
using Query.Messages.GetAllSeenMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Messages.GetAllUnseenMessages
{
    public class GetAllUnseenMessagesQuery : IRequest<IEnumerable<MessageDto>>
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
    }
}
