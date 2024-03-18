using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public UpdateReservationCommandHandler(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationEntity = await _repository.GetByIdAsync(request.ReservationId);

            if (reservationEntity != null)
            {
                _mapper.Map(request, reservationEntity);

                await _repository.UpdateAsync(reservationEntity);
            }
        }
    }
}
