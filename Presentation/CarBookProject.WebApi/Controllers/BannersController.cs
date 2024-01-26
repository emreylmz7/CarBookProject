using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBookProject.Application.Features.CQRS.Quaries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;

        public BannersController(
            CreateBannerCommandHandler createBannerCommandHandler,
            UpdateBannerCommandHandler updateBannerCommandHandler,
            RemoveBannerCommandHandler removeBannerCommandHandler,
            GetBannerQueryHandler getBannerQueryHandler,
            GetBannerByIdQueryHandler getBannerByIdQueryHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var value = await _getBannerQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner Information Added.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner Information Updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner information deleted.");
        }
    }
}
