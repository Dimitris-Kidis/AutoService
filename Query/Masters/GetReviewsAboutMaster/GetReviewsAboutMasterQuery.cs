using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetReviewsAboutMaster
{
    public class GetReviewsAboutMasterQuery : IRequest<IEnumerable<MasterReviewDto>>
    {
        public int MasterId { get; set; }
    }
}
