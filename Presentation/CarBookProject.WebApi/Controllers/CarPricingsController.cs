using CarBookProject.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarPricingWithCarList")]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarsQuery());
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarPricings() 
        {
            var carPricings = await _mediator.Send(new GetCarPricingQuery());
            return Ok(carPricings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarPricing(int id) 
        {
            var carPricing = await _mediator.Send(new GetCarPricingByIdQuery(id)); 
            return Ok(carPricing);
        }

        [HttpGet("GetCarPricingByCarId")]
        public async Task<IActionResult> GetCarPricingByCarId(int id)
        {
            var carPricing = await _mediator.Send(new GetCarPricingByCarIdQuery(id));
            return Ok(carPricing);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Car Pricing added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarPricing(int id) 
        {
            await _mediator.Send(new RemoveCarPricingCommand(id)); 
            return Ok("Car Pricing removed successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarPricing(int id, UpdateCarPricingCommand command) 
        {
            command.CarPricingId = id; 
            await _mediator.Send(command);
            return Ok("Car Pricing updated successfully");
        }

    }
}
