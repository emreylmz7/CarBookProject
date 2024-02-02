using CarBookProject.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {
    }
}
