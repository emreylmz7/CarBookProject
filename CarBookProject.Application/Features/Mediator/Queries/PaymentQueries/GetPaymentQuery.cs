using CarBookProject.Application.Features.Mediator.Results.PaymentResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.PaymentQueries
{
    public class GetPaymentQuery : IRequest<List<GetPaymentQueryResult>>
    {
    }
}
