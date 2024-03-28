
namespace CarBookProject.Dto.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ImageUrl { get; set; }
        public int BlogId { get; set; }
    }
}
