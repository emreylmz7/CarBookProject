using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.ReviewCommands
{
	public class UpdateReviewCommand : IRequest
	{
		public int ReviewId { get; set; }
		public int Rating { get; set; }
		public string? Comment { get; set; }
		public DateTime DatePosted { get; set; }
		public int CarId { get; set; }
		public int UserId { get; set; }
	}
}
