namespace CarBookProject.Application.Features.Mediator.Results.AppUserResults
{
	public class GetAppUserQueryResult
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public DateTime DateOfBirth { get; set; }
		public string? Address { get; set; }
		public byte[]? ProfilePicture { get; set; }
		public DateTime RegistrationDate { get; set; }
		public int Age { get; set; }
		public int LicenseIssuanceYear { get; set; }
		public bool IsActive { get; set; }
	}
}
