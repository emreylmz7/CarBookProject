using CarBookProject.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureQuery : IRequest<List<GetCarFeatureQueryResult>>
    {
    }
}
