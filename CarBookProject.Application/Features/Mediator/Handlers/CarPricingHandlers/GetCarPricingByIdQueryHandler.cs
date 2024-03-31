using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult> 
    {
        private readonly ICarPricingRepository _repository; 
        private readonly IMapper _mapper;

        public GetCarPricingByIdQueryHandler(ICarPricingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCarPricingByIdQueryResult> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var carPricingEntity = await _repository.GetCarPricingByIdAsync(request.Id); 
            var result = _mapper.Map<GetCarPricingByIdQueryResult>(carPricingEntity); 

            return result;
        }
    }
}
