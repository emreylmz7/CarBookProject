using CarBook.Domain.Entities;

namespace CarBookProject.Application.Features.Mediator.Results.AppUserResults
{
	public class AccountInfoQueryResult
	{
        public string? UserId { get; set; }
        public string? Name { get; set; }
		public string? Username { get; set; }
		public string? Email { get; set; }
		public string? Surname { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Address { get; set; }
		public byte[]? ProfilePicture { get; set; }
		public DateTime RegistrationDate { get; set; }
		public int Age { get; set; }
		public int LicenseIssuanceYear { get; set; }
	}
}
