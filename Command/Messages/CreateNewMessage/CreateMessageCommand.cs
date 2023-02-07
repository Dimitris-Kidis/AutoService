using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Messages.CreateNewMessage
{
    public class CreateMessageCommand : IRequest<int>
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Text { get; set; }
    }
}
