using CarBookProject.Application.Features.Mediator.Results.InvoiceResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.InvoiceQueries
{
    public class GetInvoiceByIdQuery : IRequest<GetInvoiceByIdQueryResult>
    {
        public int Id { get; set; }

        public GetInvoiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
