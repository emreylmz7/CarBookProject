using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBookProject.Application.Features.Mediator.Results.CarFeatureResults;
using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        private readonly IMapper _mapper;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carFeatureEntities = await _repository.GetCarFeaturesByCarId(request.Id);

            var results = _mapper.Map<List<GetCarFeatureByCarIdQueryResult>>(carFeatureEntities);

            return results;
        }
    }
}
