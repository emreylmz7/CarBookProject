using AutoMapper;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationEntity = _mapper.Map<Reservation>(request);
            reservationEntity.Status = ReservationStatus.Pending;
            await _repository.CreateAsync(reservationEntity);
        }
    }
}
