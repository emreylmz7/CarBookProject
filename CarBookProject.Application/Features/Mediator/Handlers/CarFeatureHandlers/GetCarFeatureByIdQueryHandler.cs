using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBookProject.Application.Features.Mediator.Results.CarFeatureResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByIdQueryHandler : IRequestHandler<GetCarFeatureByIdQuery, GetCarFeatureByIdQueryResult>
    {
        private readonly IRepository<CarFeature> _repository;
        private readonly IMapper _mapper;

        public GetCarFeatureByIdQueryHandler(IRepository<CarFeature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCarFeatureByIdQueryResult> Handle(GetCarFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var carFeatureEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetCarFeatureByIdQueryResult>(carFeatureEntity);

            return result;
        }
    }
}
