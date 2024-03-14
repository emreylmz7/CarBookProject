using CarBookProject.Application.Features.Mediator.Results.DropOffLocationResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.DropOffLocationQueries
{
    public class GetDropOffLocationByIdQuery : IRequest<GetDropOffLocationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetDropOffLocationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
