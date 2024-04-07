using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.InvoiceQueries;
using CarBookProject.Application.Features.Mediator.Results.InvoiceResults;
using CarBookProject.Application.Interfaces.InvoiceInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.InvoiceHandlers
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, GetInvoiceByIdQueryResult>
    {
        private readonly IInvoiceRepository _repository; 
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetInvoiceByIdQueryResult> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoiceEntity = await _repository.GetInvoiceById(request.Id);
            var result = _mapper.Map<GetInvoiceByIdQueryResult>(invoiceEntity);

            return result;
        }
    }
}
