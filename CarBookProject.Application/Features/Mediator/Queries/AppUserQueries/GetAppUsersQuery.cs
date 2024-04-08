using CarBookProject.Application.Features.Mediator.Results.AppUserResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetAppUsersQuery : IRequest<List<GetAppUsersQueryResult>>
    {
    }
}
