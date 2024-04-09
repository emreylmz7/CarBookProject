using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Dto.Dtos.AppUser
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Eski şifre gereklidir.")]
        public string? OldPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre gereklidir.")]
        public string? NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Yeni şifreler eşleşmiyor.")]
        public string? ConfirmNewPassword { get; set; }
    }
}
