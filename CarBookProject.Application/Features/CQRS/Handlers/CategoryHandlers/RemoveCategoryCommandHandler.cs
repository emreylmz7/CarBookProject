using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var categoryEntity = await _repository.GetByIdAsync(command.Id);

            if (categoryEntity != null)
            {
                await _repository.DeleteAsync(categoryEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
