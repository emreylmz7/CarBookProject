using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBookProject.Application.Features.Mediator.Results.CarFeatureResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureQueryHandler : IRequestHandler<GetCarFeatureQuery, List<GetCarFeatureQueryResult>>
    {
        private readonly IRepository<CarFeature> _repository;
        private readonly IMapper _mapper;

        public GetCarFeatureQueryHandler(IRepository<CarFeature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarFeatureQueryResult>> Handle(GetCarFeatureQuery request, CancellationToken cancellationToken)
        {
            var carFeatureEntities = await _repository.GetAllAsync();

            var results = _mapper.Map<List<GetCarFeatureQueryResult>>(carFeatureEntities);

            return results;
        }
    }
}
