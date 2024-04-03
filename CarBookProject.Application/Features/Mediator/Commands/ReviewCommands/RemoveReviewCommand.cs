using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.ReviewCommands
{
	public class RemoveReviewCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveReviewCommand(int id)
		{
			Id = id;
		}
	}
}
