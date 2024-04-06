using CarBookProject.Application.Features.Mediator.Results.PaymentResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.PaymentQueries
{
    public class GetPaymentByUserIdQuery : IRequest<List<GetPaymentByUserIdQueryResult>>
    {
        public int Id { get; set; }

        public GetPaymentByUserIdQuery(int id)
        {
            Id = id;
        }
    }
}
