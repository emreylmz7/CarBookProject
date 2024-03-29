using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationsWithInfoQuery : IRequest<List<GetReservationsWithInfoQueryResult>>
    {
    }
}
