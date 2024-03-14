using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.RentACarQueries;
using CarBookProject.Application.Features.Mediator.Results.RentACarResults;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Application.Interfaces.RentACarInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;
        private readonly ICarRepository _carRepository;

        public GetRentACarQueryHandler(IRentACarRepository repository, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            var cars = _carRepository.GetCarsWithBrands();
            var selectedCars = new List<Car>(); 

            foreach (var value in values)
            {
                var selectedCar = cars.FirstOrDefault(x => x.CarId == value.CarId);
                if (selectedCar != null)
                {
                    selectedCars.Add(selectedCar);
                }
            }

            return selectedCars.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarId,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                Model = x.Model,
                Km = x.Km,
                Fuel = x.Fuel.ToString(),
                TransmissionType = x.TransmissionType.ToString(),
                CoverImageUrl = x.CoverImageUrl,
                HourlyPrice = x.CarPricing != null && x.CarPricing.Any() ? x.CarPricing.First().Amount : 0
            }).ToList();
        }
    }
}
