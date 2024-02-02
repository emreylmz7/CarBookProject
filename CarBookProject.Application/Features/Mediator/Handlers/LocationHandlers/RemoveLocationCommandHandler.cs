using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.LocationCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand> 
    {
        private readonly IRepository<Location> _repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
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
