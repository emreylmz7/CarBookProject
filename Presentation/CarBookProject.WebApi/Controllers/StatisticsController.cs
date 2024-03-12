using Microsoft.AspNetCore.Mvc;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistics()
        {
            var query = new GetStatisticsQuery();
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
