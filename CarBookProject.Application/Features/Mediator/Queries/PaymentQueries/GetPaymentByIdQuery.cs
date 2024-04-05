using CarBookProject.Application.Features.Mediator.Results.PaymentResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.PaymentQueries
{
    public class GetPaymentByIdQuery : IRequest<GetPaymentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
