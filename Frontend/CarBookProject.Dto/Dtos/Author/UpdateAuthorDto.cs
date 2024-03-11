namespace CarBookProject.Dto.Dtos.Author
{
    public class UpdateAuthorDto
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
