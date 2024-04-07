using CarBookProject.Application.Features.Mediator.Queries.InvoiceQueries; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var values = await _mediator.Send(new GetInvoiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var values = await _mediator.Send(new GetInvoiceByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetInvoicesByPaymentId")]
        public async Task<IActionResult> GetInvoicesByUserId(int id)
        {
            var values = await _mediator.Send(new GetInvoiceByPaymentIdQuery(id)); 
            return Ok(values);
        }
    }
}
