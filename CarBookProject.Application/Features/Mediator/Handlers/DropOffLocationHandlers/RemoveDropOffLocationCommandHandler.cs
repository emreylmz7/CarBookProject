using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.DropOffDropOffLocationHandlers
{
    public class RemoveDropOffLocationCommandHandler : IRequestHandler<RemoveDropOffLocationCommand>
    {
        private readonly IRepository<DropOffLocation> _repository;

        public RemoveDropOffLocationCommandHandler(IRepository<DropOffLocation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveDropOffLocationCommand request, CancellationToken cancellationToken)
        {
            var locationEntity = await _repository.GetByIdAsync(request.Id);

            if (locationEntity != null)
            {
                await _repository.DeleteAsync(locationEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
