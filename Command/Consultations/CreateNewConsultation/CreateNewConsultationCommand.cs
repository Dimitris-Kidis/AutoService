using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Consultations.CreateNewConsultation
{
    public class CreateNewConsultationCommand : IRequest<int>
    {
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int CarId { get; set; }
    }
}
