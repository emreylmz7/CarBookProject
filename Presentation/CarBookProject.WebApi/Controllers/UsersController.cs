using CarBookProject.Application.Features.Mediator.Commands.AppUserCommands;
using CarBookProject.Application.Features.Mediator.Queries.AppUserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var values = await _mediator.Send(new GetAppUsersQuery());
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("User updated successfully");
        }
    }
}
