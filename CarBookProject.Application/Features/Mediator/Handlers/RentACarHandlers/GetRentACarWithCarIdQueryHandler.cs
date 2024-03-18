using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.RentACarQueries;
using CarBookProject.Application.Features.Mediator.Results.RentACarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.RentACarInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarWithCarIdQueryHandler : IRequestHandler<GetRentACarWithCarIdQuery, List<GetRentACarWithCarIdQueryResult>>
    {
        private readonly IRentACarRepository _repository;
        private readonly IRepository<Location> _locationRepository;

        public GetRentACarWithCarIdQueryHandler(IRentACarRepository repository, IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
            _repository = repository;
        }

        public async Task<List<GetRentACarWithCarIdQueryResult>> Handle(GetRentACarWithCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.CarId == request.CarId && x.Available == true);
            var locations = await _locationRepository.GetAllAsync();
            var selectedLocations = new List<Location>();

            foreach (var value in values)
            {
                var selectedLocation = locations.FirstOrDefault(x => x.LocationId == value.LocationId);
                if (selectedLocation != null)
                {
                    selectedLocations.Add(selectedLocation);
                }
            }

            return selectedLocations.Select(x => new GetRentACarWithCarIdQueryResult
            {
                Name = x.Name,
                LocationId = x.LocationId,

            }).ToList();
        }
    }
}
