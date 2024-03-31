using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.CarPricingCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers 
{
    public class RemoveCarPricingCommandHandler : IRequestHandler<RemoveCarPricingCommand> 
    {
        private readonly IRepository<CarPricing> _repository; 

        public RemoveCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarPricingCommand request, CancellationToken cancellationToken)
        {
            var carPricingEntity = await _repository.GetByIdAsync(request.Id); 

            if (carPricingEntity != null)
            {
                await _repository.DeleteAsync(carPricingEntity); 
            }
            // Optionally, you can handle the case when the car pricing with the given ID is not found.
        }
    }
}
