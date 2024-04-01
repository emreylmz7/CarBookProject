
namespace CarBook.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ImageUrl { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
    }
}
