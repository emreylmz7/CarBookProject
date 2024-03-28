using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarFeatures()
        {
            var carFeatures = await _mediator.Send(new GetCarFeatureQuery());
            return Ok(carFeatures);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeature(int id)
        {
            var carFeature = await _mediator.Send(new GetCarFeatureByIdQuery(id));
            return Ok(carFeature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Car feature added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarFeature(int id)
        {
            await _mediator.Send(new RemoveCarFeatureCommand(id));
            return Ok("Car feature removed successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarFeature(UpdateCarFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Car feature updated successfully");
        }

        [HttpGet("GetCarFeatureByCarId")]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
            var carFeature = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(carFeature);
        }
    }
}
