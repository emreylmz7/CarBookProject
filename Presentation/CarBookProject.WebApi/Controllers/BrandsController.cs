using CarBookProject.Application.Features.CQRS.Commands.BrandCommands;
using CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBookProject.Application.Features.CQRS.Quaries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

        public BrandsController(
            CreateBrandCommandHandler createBrandCommandHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler,
            RemoveBrandCommandHandler removeBrandCommandHandler,
            GetBrandQueryHandler getBrandQueryHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var value = await _getBrandQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand Information Added.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Brand Information Updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand information deleted.");
        }
    }
}
