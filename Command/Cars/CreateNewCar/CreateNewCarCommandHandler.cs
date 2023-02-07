using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Cars.CreateNewCar
{
    public class CreateNewCarCommandHandler : IRequestHandler<CreateNewCarCommand, int>
    {
        private readonly IAutoServiceRepository<Car> _carRepository;
        public CreateNewCarCommandHandler(IAutoServiceRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public Task<int> Handle(CreateNewCarCommand request, CancellationToken cancellationToken)
        {
            var newCar = new Car
            {
                ClientId = request.ClientId,
                Brand = request.Brand,
                Model = request.Model,
                Year = request.Year,
                Engine = request.Engine,
                DriveType = request.DriveType,
                Transmission = request.Transmission,
                Mileage = request.Mileage,
                Services = request.Services
            };

            _carRepository.Add(newCar);
            _carRepository.Save();

            var resultId = newCar.Id;
            return Task.FromResult(resultId);
        }
    }
}
