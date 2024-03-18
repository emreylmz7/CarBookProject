using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationQuery : IRequest<List<GetReservationQueryResult>>
    {
    }
}
