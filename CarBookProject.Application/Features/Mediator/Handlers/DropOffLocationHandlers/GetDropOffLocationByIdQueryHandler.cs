using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.DropOffLocationQueries;
using CarBookProject.Application.Features.Mediator.Results.DropOffLocationResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.DropOffDropOffLocationHandlers
{
    public class GetDropOffLocationByIdQueryHandler : IRequestHandler<GetDropOffLocationByIdQuery, GetDropOffLocationByIdQueryResult>
    {
        private readonly IRepository<DropOffLocation> _repository;
        private readonly IMapper _mapper;

        public GetDropOffLocationByIdQueryHandler(IRepository<DropOffLocation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetDropOffLocationByIdQueryResult> Handle(GetDropOffLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var locationEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetDropOffLocationByIdQueryResult>(locationEntity);

            return result;
        }
    }
}
