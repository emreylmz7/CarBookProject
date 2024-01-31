using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var carEntity = await _repository.GetByIdAsync(command.Id);

            if (carEntity != null)
            {
                await _repository.DeleteAsync(carEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
