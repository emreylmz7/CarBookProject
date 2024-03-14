using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.DropOffLocationQueries;
using CarBookProject.Application.Features.Mediator.Results.DropOffLocationResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.DropOffDropOffLocationHandlers
{
    public class GetDropOffLocationsQueryHandler : IRequestHandler<GetDropOffLocationQuery, List<GetDropOffLocationQueryResult>>
    {
        private readonly IRepository<DropOffLocation> _repository;
        private readonly IMapper _mapper;

        public GetDropOffLocationsQueryHandler(IRepository<DropOffLocation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetDropOffLocationQueryResult>> Handle(GetDropOffLocationQuery request, CancellationToken cancellationToken)
        {
            var locationEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetDropOffLocationQueryResult>>(locationEntities);

            return results;
        }
    }
}
