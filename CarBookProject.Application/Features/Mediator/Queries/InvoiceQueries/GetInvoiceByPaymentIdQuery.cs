using CarBookProject.Application.Features.Mediator.Results.InvoiceResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.InvoiceQueries
{
    public class GetInvoiceByPaymentIdQuery : IRequest<List<GetInvoiceByPaymentIdQueryResult>>
    {
        public int Id { get; set; }

        public GetInvoiceByPaymentIdQuery(int id)
        {
            Id = id;
        }
    }
}
