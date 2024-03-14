using CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands;
using CarBookProject.Application.Features.Mediator.Queries.DropOffLocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropOffLocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DropOffLocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDropOffLocations()
        {
            var values = await _mediator.Send(new GetDropOffLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDropOffLocation(int id)
        {
            var values = await _mediator.Send(new GetDropOffLocationByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDropOffLocation(CreateDropOffLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("DropOffLocation added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDropOffLocation(int id)
        {
            await _mediator.Send(new RemoveDropOffLocationCommand(id));
            return Ok("DropOffLocation removed successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDropOffLocation(UpdateDropOffLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("DropOffLocation updated successfully");
        }
    }
}
