using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Client.GetClientHistory
{
    public class GetClientHistoryQuery : IRequest<IEnumerable<ClientHistoryDto>>
    {
        public int ClientId { get; set; }
    }
}
