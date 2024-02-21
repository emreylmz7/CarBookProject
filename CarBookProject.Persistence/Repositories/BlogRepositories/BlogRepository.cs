using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthor()
        {
            var values = await _context.Blogs!
                .Include(x => x.Category)
                .Include(x => x.Author)
                .ToListAsync();

            return values;
        }

        public async Task<List<Blog>> GetLast3BlogsWihtAuthors()
        {
            var values = await _context.Blogs!
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.BlogId)
                .Take(3)
                .ToListAsync();

            return values;
        }
    }
}
