using CarBookProject.Application.Features.Mediator.Commands.CarDescriptionCommands; 
using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarDescriptions()
        {
            var carDescriptions = await _mediator.Send(new GetCarDescriptionQuery());
            return Ok(carDescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDescription(int id)
        {
            var carDescription = await _mediator.Send(new GetCarDescriptionByIdQuery(id));
            return Ok(carDescription);
        }

        [HttpGet("GetCarDescriptionByCarId")]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
        {
            var carDescription = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(carDescription);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarDescription(CreateCarDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Car description added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCarDescription(int id)
        {
            await _mediator.Send(new RemoveCarDescriptionCommand(id));
            return Ok("Car description removed successfully");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCarDescription(UpdateCarDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Car description updated successfully");
        }
    }
}
