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
        private readonly IAutoServiceRepository<Car> _carsRepository;
        public CreateNewConsultationCommandHandler(
            IAutoServiceRepository<Consultation> consultationRepository, IAutoServiceRepository<Car> carsRepository)
        {
            _consultationRepository = consultationRepository;
            _carsRepository = carsRepository;
        }
        public Task<int> Handle(CreateNewConsultationCommand request, CancellationToken cancellationToken)
        {
            var carId = _carsRepository.FindBy(car => car.ClientId == request.ClientId).LastOrDefault().Id;
            var newCons = new Consultation
            {
                ClientId = request.ClientId,
                MasterId = request.MasterId,
                CarId = carId,

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
