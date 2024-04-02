using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Dto.Dtos.Authentication
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
