namespace CarBookProject.Dto.Dtos.Blog
{
    public class CreateBlogDto
    {
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
    }
}
