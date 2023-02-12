using MediatR;
using Query.Masters.GetMasterInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.MasterCabinetInfo
{
    public class GetMasterCabinetInfoQuery : IRequest<MasterInfoDto>
    {
        public int MasterId { get; set; }
    }
}
