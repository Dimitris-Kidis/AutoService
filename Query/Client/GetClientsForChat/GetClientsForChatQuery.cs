using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Client.GetClientsForChat
{
    public class GetClientsForChatQuery : IRequest<IEnumerable<ClientsForChatDto>>
    {
        public int MasterId { get; set; }
    }
}
