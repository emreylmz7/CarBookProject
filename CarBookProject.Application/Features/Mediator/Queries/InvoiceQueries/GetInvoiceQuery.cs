using CarBookProject.Application.Features.Mediator.Results.InvoiceResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.InvoiceQueries
{
    public class GetInvoiceQuery : IRequest<List<GetInvoiceQueryResult>>
    {
    }
}
