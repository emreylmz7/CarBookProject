using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.CarDescriptionCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class RemoveCarDescriptionCommandHandler : IRequestHandler<RemoveCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public RemoveCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var carDescription = await _repository.GetByIdAsync(request.Id);

            if (carDescription != null)
            {
                // Perform any necessary business logic before deletion (e.g., handling references)
                // ...

                await _repository.DeleteAsync(carDescription);
            }
            else
            {
                // Handle the case where the car description is not found (e.g., log a warning)
                // ...
            }
        }
    }
}
