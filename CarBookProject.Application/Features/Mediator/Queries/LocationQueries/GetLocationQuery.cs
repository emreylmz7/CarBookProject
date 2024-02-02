using CarBookProject.Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
    {
    }
}
