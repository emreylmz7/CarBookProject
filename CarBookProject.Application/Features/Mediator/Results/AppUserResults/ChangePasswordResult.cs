namespace CarBookProject.Application.Features.Mediator.Results.AppUserResults
{
    public class ChangePasswordResult
    {
        public string? Username { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
