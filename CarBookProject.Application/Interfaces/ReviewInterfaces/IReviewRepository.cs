using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.ReviewInterfaces
{
	public interface IReviewRepository
	{
		Task<List<Review>> GetReviewsByCarId(int id);
		Task<List<Review>> GetAllReviews();
		Task<Review> GetReviewById(int id);
	}
}
