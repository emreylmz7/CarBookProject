using CarBook.Domain.Entities; 
using CarBookProject.Application.Interfaces.ReviewInterfaces; 
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.ReviewRepositories 
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly CarBookContext _context;

		public ReviewRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<List<Review>> GetAllReviews()
		{
			return await _context.Reviews
				.Include(x=> x.AppUser)
				.ToListAsync();
		}

		public async Task<Review> GetReviewById(int id)
		{
			var entity = await _context.Reviews
				.Include(x => x.AppUser)
				.FirstOrDefaultAsync(x=>x.ReviewId == id);
			return entity!;
		}

		public async Task<List<Review>> GetReviewsByCarId(int id) 
		{
			var values = await _context.Reviews! 
				.Include(x => x.AppUser) 
				.Where(x => x.CarId == id)
				.ToListAsync();
			return values;
		}
	}
}
