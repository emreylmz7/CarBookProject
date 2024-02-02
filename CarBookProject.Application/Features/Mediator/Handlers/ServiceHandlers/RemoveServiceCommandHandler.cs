using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ServiceCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers 
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand> 
    {
        private readonly IRepository<Service> _repository; 

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceEntity = await _repository.GetByIdAsync(request.Id); 

            if (serviceEntity != null)
            {
                await _repository.DeleteAsync(serviceEntity); 
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
