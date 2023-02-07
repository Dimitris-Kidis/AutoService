using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetMasterHistory
{
    public class GetMasterHistoryQuery : IRequest<IEnumerable<MasterHistoryDto>>
    {
        public int MasterId { get; set; }
    }
}
