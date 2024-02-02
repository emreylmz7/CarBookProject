using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.LocationQueries; 
using CarBookProject.Application.Features.Mediator.Results.LocationResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.LocationHandlers 
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult> 
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var locationEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetLocationByIdQueryResult>(locationEntity);

            return result;
        }
    }
}
