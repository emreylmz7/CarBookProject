using CarBookProject.Application.Features.Mediator.Commands.ServiceCommands; 
using CarBookProject.Application.Features.Mediator.Queries.ServiceQueries; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var services = await _mediator.Send(new GetServiceQuery()); 
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var service = await _mediator.Send(new GetServiceByIdQuery(id)); 
            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command); 
            return Ok("Service added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id)); 
            return Ok("Service removed successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command); 
            return Ok("Service updated successfully");
        }
    }
}
