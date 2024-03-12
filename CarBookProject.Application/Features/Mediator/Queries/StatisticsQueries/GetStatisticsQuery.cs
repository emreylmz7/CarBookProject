using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetStatisticsQuery : IRequest<GetStatisticsQueryResult>
    {
    }
}
