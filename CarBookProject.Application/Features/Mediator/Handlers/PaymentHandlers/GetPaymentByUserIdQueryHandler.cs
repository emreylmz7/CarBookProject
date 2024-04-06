using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.PaymentQueries;
using CarBookProject.Application.Features.Mediator.Results.PaymentResults;
using CarBookProject.Application.Interfaces.PaymentInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PaymentHandlers
{
    public class GetPaymentByUserIdQueryHandler : IRequestHandler<GetPaymentByUserIdQuery, List<GetPaymentByUserIdQueryResult>>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public GetPaymentByUserIdQueryHandler(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetPaymentByUserIdQueryResult>> Handle(GetPaymentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var paymentEntity = await _repository.GetPaymentsByUserId(request.Id);
            var result = _mapper.Map<List<GetPaymentByUserIdQueryResult>>(paymentEntity);
            return result;
        }
    }
}
