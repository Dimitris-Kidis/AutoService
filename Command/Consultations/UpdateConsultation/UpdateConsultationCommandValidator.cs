using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Consultations.UpdateConsultation
{
    public class UpdateConsultationCommandValidator : AbstractValidator<UpdateConsultationCommand>
    {
        public UpdateConsultationCommandValidator()
        {
            RuleFor(cons => cons.Stars)
                .InclusiveBetween(0, 10);
        }
    }
}
