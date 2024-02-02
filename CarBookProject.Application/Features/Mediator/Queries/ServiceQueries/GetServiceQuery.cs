using CarBookProject.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {
    }
}
