using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingQuery : IRequest<List<GetCarPricingQueryResult>>
    {
    }
}
