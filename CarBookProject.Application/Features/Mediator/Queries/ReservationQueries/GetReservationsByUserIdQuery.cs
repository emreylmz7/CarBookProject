using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationsByUserIdQuery : IRequest<List<GetReservationsByUserIdQueryResult>>
    {
        public int Id { get; set; }

        public GetReservationsByUserIdQuery(int id)
        {
            Id = id;
        }
    }
}
