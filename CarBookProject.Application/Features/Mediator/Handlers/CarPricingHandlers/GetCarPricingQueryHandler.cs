using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingsQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>> 
    {
        private readonly ICarPricingRepository _repository; 
        private readonly IMapper _mapper;

        public GetCarPricingsQueryHandler(ICarPricingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var carPricingEntities = await _repository.GetCarPricingsAsync();

            var results = _mapper.Map<List<GetCarPricingQueryResult>>(carPricingEntities); 

            return results;
        }
    }
}
