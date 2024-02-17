using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Dto.Dtos.About
{
    public class ResultAboutDto
    {
        public int aboutId { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public string? imageUrl { get; set; }
    }
}
