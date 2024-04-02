namespace CarBookProject.Application.Interfaces.AuthenticationInterfaces
{
	public interface IAuthenticatedUserRepository
	{
		public string UserId { get; }
		public string Username { get; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Address { get; set; }
		public byte[]? ProfilePicture { get; set; }
		public DateTime RegistrationDate { get; set; }
		public int Age { get; set; }
		public int LicenseIssuanceYear { get; set; }
		public bool IsActive { get; set; }
	}
}
