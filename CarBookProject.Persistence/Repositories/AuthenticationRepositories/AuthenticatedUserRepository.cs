using CarBookProject.Application.Interfaces.AuthenticationInterfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CarBookProject.Persistence.Repositories.AuthenticationRepositories
{
	public class AuthenticatedUserRepository : IAuthenticatedUserRepository
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthenticatedUserRepository(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;

			UserId = GetUserId();
			Username = GetUsername();
			Name = GetName();
			Surname = GetSurname();
			DateOfBirth = GetDateOfBirth();
			Address = GetAddress();
			ProfilePicture = GetProfilePicture();
			RegistrationDate = GetRegistrationDate();
			Age = GetAge();
			LicenseIssuanceYear = GetLicenseIssuanceYear();
			IsActive = GetIsActive();
		}

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

		private string GetUserId()
		{
			return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
		}

		private string GetUsername()
		{
			return _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "";
		}

		private string GetName()
		{
			return _httpContextAccessor.HttpContext?.User?.FindFirstValue("Name") ?? "";
		}

		private string GetSurname()
		{
			return _httpContextAccessor.HttpContext?.User?.FindFirstValue("Surname") ?? "";
		}

		private DateTime? GetDateOfBirth()
		{
			string dateOfBirthString = _httpContextAccessor.HttpContext?.User?.FindFirstValue("DateOfBirth") ?? "";
			if (!string.IsNullOrEmpty(dateOfBirthString) && DateTime.TryParse(dateOfBirthString, out DateTime createAt))
			{
				return createAt;
			}
			return null;
		}

		private string GetAddress()
		{
			return _httpContextAccessor.HttpContext?.User?.FindFirstValue("Address") ?? "";
		}

		private byte[]? GetProfilePicture()
		{
			return _httpContextAccessor.HttpContext?.User?.FindFirstValue("ProfilePicture") != null ?
				   Convert.FromBase64String(_httpContextAccessor.HttpContext.User.FindFirstValue("ProfilePicture")!) :
				   null;
		}

		private DateTime GetRegistrationDate()
		{
			return _httpContextAccessor.HttpContext?.User?.FindFirstValue("RegistrationDate") != null ?
				   DateTime.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue("RegistrationDate")!) :
				   DateTime.MinValue;
		}

		private int GetAge()
		{
			string ageString = _httpContextAccessor.HttpContext?.User?.FindFirstValue("Age") ?? "0";
			return int.TryParse(ageString, out int age) ? age : 0;
		}

		private int GetLicenseIssuanceYear()
		{
			string issuanceYearString = _httpContextAccessor.HttpContext?.User?.FindFirstValue("LicenseIssuanceYear") ?? "0";
			return int.TryParse(issuanceYearString, out int issuanceYear) ? issuanceYear : 0;
		}

		private bool GetIsActive()
		{
			string isActiveString = _httpContextAccessor.HttpContext?.User?.FindFirstValue("IsActive") ?? "false";
			return bool.TryParse(isActiveString, out bool isActive) && isActive;
		}
	}
}
