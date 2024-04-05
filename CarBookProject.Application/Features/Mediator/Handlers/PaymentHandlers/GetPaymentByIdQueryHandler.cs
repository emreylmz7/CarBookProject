using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Queries.PaymentQueries; 
using CarBookProject.Application.Features.Mediator.Results.PaymentResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PaymentHandlers // Adjust namespace for payment handlers
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, GetPaymentByIdQueryResult>
    {
        private readonly IRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public GetPaymentByIdQueryHandler(IRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPaymentByIdQueryResult> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var paymentEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetPaymentByIdQueryResult>(paymentEntity);

            return result;
        }
    }
}
