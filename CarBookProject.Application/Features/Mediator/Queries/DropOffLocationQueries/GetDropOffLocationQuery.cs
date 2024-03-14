using CarBookProject.Application.Features.Mediator.Results.DropOffLocationResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.DropOffLocationQueries
{
    public class GetDropOffLocationQuery : IRequest<List<GetDropOffLocationQueryResult>>
    {
    }
}
