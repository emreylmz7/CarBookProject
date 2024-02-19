using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWihtAuthors();
    }
}
