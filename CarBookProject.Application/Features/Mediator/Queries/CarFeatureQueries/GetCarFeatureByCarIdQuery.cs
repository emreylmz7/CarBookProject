using CarBookProject.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery : IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCarFeatureByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
