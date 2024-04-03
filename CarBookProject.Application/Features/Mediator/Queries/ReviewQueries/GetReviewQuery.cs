using CarBookProject.Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewQuery : IRequest<List<GetReviewQueryResult>>
	{
	}
}
