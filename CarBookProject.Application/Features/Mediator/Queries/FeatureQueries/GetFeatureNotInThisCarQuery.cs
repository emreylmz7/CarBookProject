using CarBookProject.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureNotInThisCarQuery : IRequest<List<GetFeatureNotInThisCarQueryResult>>
    {
        public int Id { get; set; }

        public GetFeatureNotInThisCarQuery(int id)
        {
            Id = id;
        }
    }
}
