using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.InvoiceQueries;
using CarBookProject.Application.Features.Mediator.Results.InvoiceResults;
using CarBookProject.Application.Interfaces.InvoiceInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.InvoiceHandlers
{
    public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, List<GetInvoiceQueryResult>>
    {
        private readonly IInvoiceRepository _repository; 
        private readonly IMapper _mapper;

        public GetInvoiceQueryHandler(IInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetInvoiceQueryResult>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoiceEntities = await _repository.GetInvoices();
            var results = _mapper.Map<List<GetInvoiceQueryResult>>(invoiceEntities);

            return results;
        }
    }
}
