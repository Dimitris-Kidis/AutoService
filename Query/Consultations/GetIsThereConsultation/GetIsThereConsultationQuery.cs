using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Consultations.GetIsThereConsultation
{
    public class GetIsThereConsultationQuery : IRequest<IsThereConsultationDto>
    {
        public bool Role { get; set; }
        public int UserId { get; set; }
    }
}
