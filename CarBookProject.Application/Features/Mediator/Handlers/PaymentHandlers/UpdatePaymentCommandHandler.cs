using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.PaymentCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PaymentHandlers
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
    {
        private readonly IRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public UpdatePaymentCommandHandler(IRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentEntity = await _repository.GetByIdAsync(request.PaymentId);

            if (paymentEntity != null)
            {
                _mapper.Map(request, paymentEntity);

                await _repository.UpdateAsync(paymentEntity);
            }
        }
    }
}
