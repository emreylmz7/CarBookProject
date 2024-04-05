using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _mediator.Send(new GetReservationQuery());
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var reservation = await _mediator.Send(new GetReservationByIdQuery(id));
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            int id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            await _mediator.Send(new RemoveReservationCommand(id));
            return Ok("Reservation removed successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Reservation updated successfully");
        }

        [HttpGet("GetReservationsWithInfo")]
        public async Task<IActionResult> GetReservationsWithInfo()
        {
            var reservations = await _mediator.Send(new GetReservationsWithInfoQuery());
            return Ok(reservations);
        }

        [HttpGet("GetReservationByUserId")]
        public async Task<IActionResult> GetReservationByUserId(int id)
        {
            var reservations = await _mediator.Send(new GetReservationsByUserIdQuery(id));
            return Ok(reservations);
        }
    }
}
