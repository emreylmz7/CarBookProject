using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentByBlogId(int id) 
        {
            var values = await _context.Comments!.Where(x => x.BlogId == id).ToListAsync(); 
            return values;
        }
    }
}
