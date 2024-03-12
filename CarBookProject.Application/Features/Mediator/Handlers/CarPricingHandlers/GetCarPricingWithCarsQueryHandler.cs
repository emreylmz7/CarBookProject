using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarsQueryHandler : IRequestHandler<GetCarPricingWithCarsQuery, List<GetCarPricingWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        private readonly IMapper _mapper;
        public GetCarPricingWithCarsQueryHandler(ICarPricingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
        {
            var carsEntities = await _repository.GetCarPricingsWithCarsAsync();
            var results = _mapper.Map<List<GetCarPricingWithCarsQueryResult>>(carsEntities);

            return results;
        }
    }
}
