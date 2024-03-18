using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class RemoveReservationCommandHandler : IRequestHandler<RemoveReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public RemoveReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationEntity = await _repository.GetByIdAsync(request.Id);

            if (reservationEntity != null)
            {
                await _repository.DeleteAsync(reservationEntity);
            }
            // Opsiyonel olarak, verilen ID'ye sahip varlık bulunamadığında bu durumu işleyebilirsiniz.
        }
    }
}
