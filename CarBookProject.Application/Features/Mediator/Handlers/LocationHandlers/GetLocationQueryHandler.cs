using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.LocationQueries;
using CarBookProject.Application.Features.Mediator.Results.LocationResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>> 
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;

        public GetLocationsQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var locationEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetLocationQueryResult>>(locationEntities);

            return results;
        }
    }
}
