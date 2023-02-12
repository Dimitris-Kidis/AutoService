using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Client.GetCurrentConsultation
{
    public class GetCurrentConsultationQuery : IRequest<CurrentConsultationDto>
    {
        public bool Role { get; set; }
        public int UserId { get; set; }
    }
}
