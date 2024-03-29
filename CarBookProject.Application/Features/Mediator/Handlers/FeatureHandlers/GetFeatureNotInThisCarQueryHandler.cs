using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProject.Application.Features.Mediator.Results.FeatureResults;
using CarBookProject.Application.Interfaces.FeatureInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureNotInThisCarQueryHandler : IRequestHandler<GetFeatureNotInThisCarQuery, List<GetFeatureNotInThisCarQueryResult>>
    {
        private readonly IFeatureRepository _repository;
        private readonly IMapper _mapper;
        public GetFeatureNotInThisCarQueryHandler(IFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetFeatureNotInThisCarQueryResult>> Handle(GetFeatureNotInThisCarQuery request, CancellationToken cancellationToken)
        {
            var featureEntity = await _repository.GetFeaturesNotInThisCar(request.Id);
            var result = _mapper.Map<List<GetFeatureNotInThisCarQueryResult>>(featureEntity);

            return result;
        }
    }
}
