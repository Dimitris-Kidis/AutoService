using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Messages.GetAllSeenMessages
{
    public class GetAllSeenMessagesQuery : IRequest<IEnumerable<MessageDto>>
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
    }
}
