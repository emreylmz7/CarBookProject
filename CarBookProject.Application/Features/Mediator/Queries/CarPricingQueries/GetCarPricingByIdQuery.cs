
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByIdQuery : IRequest<GetCarPricingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
