using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Consultations.CreateNewConsultation
{
    public class CreateNewConsultationCommandHandler : IRequestHandler<CreateNewConsultationCommand, int>
    {
        private readonly IAutoServiceRepository<Consultation> _consultationRepository;
        public CreateNewConsultationCommandHandler(IAutoServiceRepository<Consultation> consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }
        public Task<int> Handle(CreateNewConsultationCommand request, CancellationToken cancellationToken)
        {
            var newCons = new Consultation
            {
                ClientId = request.ClientId,
                MasterId = request.MasterId,
                CarId = request.CarId,
                Rated = false,
                Done = false,
                Stars = 0,
                Comment = ""
            };

            _consultationRepository.Add(newCons);
            _consultationRepository.Save();

            var resultId = newCons.Id;
            return Task.FromResult(resultId);
        }
    }
}
