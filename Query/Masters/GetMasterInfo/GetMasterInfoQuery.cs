using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetMasterInfo
{
    public class GetMasterInfoQuery : IRequest<MasterInfoDto>
    {
        public int ClientId { get; set; }
    }
}
