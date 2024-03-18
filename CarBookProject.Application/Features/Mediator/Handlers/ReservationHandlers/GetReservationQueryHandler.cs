using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.ReservationQueries;
using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using CarBookProject.Application.Interfaces;
using MediatR;
using System.Collections.Generic;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public GetReservationsQueryHandler(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var reservationEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetReservationQueryResult>>(reservationEntities);

            return results;
        }
    }
}
