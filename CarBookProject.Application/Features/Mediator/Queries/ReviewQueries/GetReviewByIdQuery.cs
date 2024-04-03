using CarBookProject.Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewByIdQuery : IRequest<GetReviewByIdQueryResult>
	{
		public int Id { get; set; }

		public GetReviewByIdQuery(int id)
		{
			Id = id;
		}
	}
}
