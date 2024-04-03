using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.ReviewCommands
{
	public class CreateReviewCommand : IRequest
	{
		public int Rating { get; set; }
		public string? Comment { get; set; }
		public DateTime DatePosted { get; set; }
		public int CarId { get; set; }
		public int AppUserId { get; set; }
	}
}
