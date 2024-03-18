using CarBookProject.Application.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationByIdQuery : IRequest<GetReservationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetReservationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
