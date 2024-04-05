using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.PaymentCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PaymentHandlers 
{
    public class RemovePaymentCommandHandler : IRequestHandler<RemovePaymentCommand>
    {
        private readonly IRepository<Payment> _repository;

        public RemovePaymentCommandHandler(IRepository<Payment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentEntity = await _repository.GetByIdAsync(request.Id);

            if (paymentEntity != null)
            {
                await _repository.DeleteAsync(paymentEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
