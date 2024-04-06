using CarBookProject.Application.Features.Mediator.Commands.PaymentCommands; 
using CarBookProject.Application.Features.Mediator.Queries.PaymentQueries; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments() 
        {
            var values = await _mediator.Send(new GetPaymentQuery()); 
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id) 
        {
            var values = await _mediator.Send(new GetPaymentByIdQuery(id)); 
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Payment added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePayment(int id) 
        {
            await _mediator.Send(new RemovePaymentCommand(id));
            return Ok("Payment removed successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment(UpdatePaymentCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Payment updated successfully");
        }

        [HttpGet("GetPaymentByUserId")]
        public async Task<IActionResult> GetPaymentByUserId(int id)
        {
            var values = await _mediator.Send(new GetPaymentByUserIdQuery(id));
            return Ok(values);
        }
    }
}
