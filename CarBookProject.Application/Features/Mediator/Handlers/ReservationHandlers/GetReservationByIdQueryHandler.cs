using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.ReservationQueries;
using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public GetReservationByIdQueryHandler(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservationEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetReservationByIdQueryResult>(reservationEntity);

            return result;
        }
    }
}
