using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Consultations.UpdateConsultation
{
    public class UpdateConsultationCommandHandler : IRequestHandler<UpdateConsultationCommand, int>
    {
        private readonly IAutoServiceRepository<Consultation> _consRepository;
        public UpdateConsultationCommandHandler(IAutoServiceRepository<Consultation> consRepository)
        {
            _consRepository = consRepository;
        }
        public Task<int> Handle(UpdateConsultationCommand request, CancellationToken cancellationToken)
        {
            if (!request.Role)
            {
                var cons = _consRepository.FindBy(cons => cons.ClientId == request.ClientId).LastOrDefault();

                cons.Done = request.Done;
                cons.Stars = request.Stars;
                cons.Comment = request.Comment;
                cons.Rated = request.Rated;

                _consRepository.Update(cons);
                _consRepository.Save();
            }
            else
            {
                var cons = _consRepository.FindBy(cons => cons.ClientId == request.ClientId && cons.MasterId == request.MasterId).LastOrDefault();

                cons.Done = request.Done;
                cons.Stars = request.Stars;
                cons.Comment = request.Comment;
                cons.Rated = request.Rated;

                _consRepository.Update(cons);
                _consRepository.Save();
            }



            

            return Task.FromResult(0);
        }
    }
}
