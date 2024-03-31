using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByCarIdQueryHandler : IRequestHandler<GetCarPricingByCarIdQuery, List<GetCarPricingByCarIdQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        private readonly IMapper _mapper;

        public GetCarPricingByCarIdQueryHandler(ICarPricingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetCarPricingByCarIdQueryResult>> Handle(GetCarPricingByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carPricingEntity = await _repository.GetCarPricingByCarIdAsync(request.Id);
            var result = _mapper.Map<List<GetCarPricingByCarIdQueryResult>>(carPricingEntity);

            return result;
        }
    }
}
