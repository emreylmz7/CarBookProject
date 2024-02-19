using CarBookProject.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQuery : IRequest<List<GetAuthorQueryResult>>
    {
    }
}
