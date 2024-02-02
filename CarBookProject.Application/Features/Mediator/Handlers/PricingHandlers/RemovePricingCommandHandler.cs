using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.PricingCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var pricingEntity = await _repository.GetByIdAsync(request.Id);

            if (pricingEntity != null)
            {
                await _repository.DeleteAsync(pricingEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
