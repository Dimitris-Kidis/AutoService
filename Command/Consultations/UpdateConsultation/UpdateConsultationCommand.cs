using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Consultations.UpdateConsultation
{
    public class UpdateConsultationCommand : IRequest<int>
    {
        public bool Role { get; set; }
        public int ClientId { get; set; }
        public int? MasterId { get; set; }
        public bool Done { get; set; }
        public bool Rated { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }
}
