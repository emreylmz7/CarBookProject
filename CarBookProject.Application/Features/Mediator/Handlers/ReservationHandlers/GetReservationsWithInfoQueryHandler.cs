using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.ReservationQueries;
using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using CarBookProject.Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationsWithInfoQueryHandler : IRequestHandler<GetReservationsWithInfoQuery, List<GetReservationsWithInfoQueryResult>>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public GetReservationsWithInfoQueryHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetReservationsWithInfoQueryResult>> Handle(GetReservationsWithInfoQuery request, CancellationToken cancellationToken)
        {
            var reservationEntities = await _repository.GetReservationsWithInfo();

            var results = _mapper.Map<List<GetReservationsWithInfoQueryResult>>(reservationEntities);

            return results;
        }
    }
}
