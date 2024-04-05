using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Queries.PaymentQueries; 
using CarBookProject.Application.Features.Mediator.Results.PaymentResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PaymentHandlers 
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentQuery, List<GetPaymentQueryResult>>
    {
        private readonly IRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public GetPaymentsQueryHandler(IRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetPaymentQueryResult>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var paymentEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetPaymentQueryResult>>(paymentEntities);

            return results;
        }
    }
}
