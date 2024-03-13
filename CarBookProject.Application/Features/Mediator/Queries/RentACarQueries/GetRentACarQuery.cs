using CarBookProject.Application.Features.Mediator.Results.RentACarResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationId { get; set; }
        public bool Available { get; set; }

    }
}
