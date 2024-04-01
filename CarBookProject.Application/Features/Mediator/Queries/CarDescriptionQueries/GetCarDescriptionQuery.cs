using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionQuery : IRequest<List<GetCarDescriptionQueryResult>>
    {
    }
}
