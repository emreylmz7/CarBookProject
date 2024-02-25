
namespace CarBookProject.Dto.Dtos.Comment
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ImageUrl { get; set; }
        public int BlogId { get; set; }
    }
}
