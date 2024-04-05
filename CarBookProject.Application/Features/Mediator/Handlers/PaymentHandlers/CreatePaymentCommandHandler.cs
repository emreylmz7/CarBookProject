using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.PaymentCommands; 
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.PaymentInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PaymentHandlers 
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentEntity = _mapper.Map<Payment>(request);
            await _repository.CreatePayment(paymentEntity);
        }
    }
}
