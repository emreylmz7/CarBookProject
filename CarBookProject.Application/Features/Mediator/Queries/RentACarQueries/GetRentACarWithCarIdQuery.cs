using CarBookProject.Application.Features.Mediator.Results.RentACarResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarWithCarIdQuery : IRequest<List<GetRentACarWithCarIdQueryResult>>
    {
        public int CarId { get; set; }
        public bool Available { get; set; }
    }
}
