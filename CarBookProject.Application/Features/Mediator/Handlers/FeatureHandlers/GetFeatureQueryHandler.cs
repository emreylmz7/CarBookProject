using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProject.Application.Features.Mediator.Results.FeatureResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetFeatureQueryHandler(IRepository<Feature> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var featureEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetFeatureQueryResult>>(featureEntities);

            return results;
        }
    }
}
