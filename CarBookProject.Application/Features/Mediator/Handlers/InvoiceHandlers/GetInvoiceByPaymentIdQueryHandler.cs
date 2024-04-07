using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.InvoiceQueries;
using CarBookProject.Application.Features.Mediator.Results.InvoiceResults;
using CarBookProject.Application.Interfaces.InvoiceInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.InvoiceHandlers 
{
    public class GetInvoiceByPaymentIdQueryHandler : IRequestHandler<GetInvoiceByPaymentIdQuery, List<GetInvoiceByPaymentIdQueryResult>>
    {
        private readonly IInvoiceRepository _repository; 
        private readonly IMapper _mapper;

        public GetInvoiceByPaymentIdQueryHandler(IInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetInvoiceByPaymentIdQueryResult>> Handle(GetInvoiceByPaymentIdQuery request, CancellationToken cancellationToken)
        {
            var invoiceEntities = await _repository.GetInvoicesByPaymentId(request.Id);
            var result = _mapper.Map<List<GetInvoiceByPaymentIdQueryResult>>(invoiceEntities);

            return result;
        }
    }
}
