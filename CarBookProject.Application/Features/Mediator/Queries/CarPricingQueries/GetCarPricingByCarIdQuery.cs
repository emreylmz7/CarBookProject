using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByCarIdQuery : IRequest<List<GetCarPricingByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCarPricingByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
