﻿using AutoMapper;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationEntity = _mapper.Map<Reservation>(request);
            reservationEntity.Status = ReservationStatus.Pending;
            await _repository.CreateReservationWithTotalCost(reservationEntity);
        }
    }
}
