
namespace CarBookProject.Dto.Dtos.Blog
{
    public class ResultLast3BlogDto
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
