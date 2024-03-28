using CarBookProject.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByIdQuery : IRequest<GetCarFeatureByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
