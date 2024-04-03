namespace CarBookProject.Application.Features.Mediator.Results.ReviewResults
{
	public class GetReviewByIdQueryResult
	{
		public int ReviewId { get; set; }
		public int Rating { get; set; }
		public string? Comment { get; set; }
		public DateTime DatePosted { get; set; }
		public int CarId { get; set; }
		public string? UserImage { get; set; }
		public string? UserName { get; set; }
	}
}
