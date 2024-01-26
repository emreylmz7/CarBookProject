using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BrandCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var brandEntity = await _repository.GetByIdAsync(command.Id);

            if (brandEntity != null)
            {
                await _repository.DeleteAsync(brandEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
