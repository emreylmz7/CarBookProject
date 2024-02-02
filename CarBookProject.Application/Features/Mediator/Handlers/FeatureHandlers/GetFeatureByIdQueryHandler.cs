using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProject.Application.Features.Mediator.Results.FeatureResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetFeatureByIdQueryHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var featureEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetFeatureByIdQueryResult>(featureEntity);

            return result;
        }
    }
}
