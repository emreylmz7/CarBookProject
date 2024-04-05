using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.ReservationQueries;
using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using CarBookProject.Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationsByUserIdQueryHandler : IRequestHandler<GetReservationsByUserIdQuery, List<GetReservationsByUserIdQueryResult>>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public GetReservationsByUserIdQueryHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetReservationsByUserIdQueryResult>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reservationEntities = await _repository.GetReservationsByUserId(request.Id);
            var results = _mapper.Map<List<GetReservationsByUserIdQueryResult>>(reservationEntities);

            return results;
        }
    }
}
