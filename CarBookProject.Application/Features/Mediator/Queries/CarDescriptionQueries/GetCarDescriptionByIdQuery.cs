using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByIdQuery : IRequest<GetCarDescriptionByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
