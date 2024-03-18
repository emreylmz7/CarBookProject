using CarBookProject.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetRentACarListByLocation")]
        public async Task<IActionResult> GetRentACarListByLocation(int locationId,bool available)
        {
            GetRentACarQuery query = new GetRentACarQuery()
            {
                Available = available,
                LocationId = locationId
            };
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpGet("GetRentACarLocationListByCarId")]
        public async Task<IActionResult> GetRentACarLocationListByCarId(int carId, bool available)
        {
            GetRentACarWithCarIdQuery query = new GetRentACarWithCarIdQuery()
            {
                Available = available,
                CarId = carId
            };
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
