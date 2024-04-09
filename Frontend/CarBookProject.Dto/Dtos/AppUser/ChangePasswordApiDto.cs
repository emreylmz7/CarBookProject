namespace CarBookProject.Dto.Dtos.AppUser
{
    public class ChangePasswordApiDto
    {
        public string? Username { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
