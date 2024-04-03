using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Application.Features.Mediator.Results.AppUserResults
{
	public class GetAppUserQueryResult
	{
		[Required(ErrorMessage = "Name is required")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Surname is required")]
		public string? Surname { get; set; }

		[Required(ErrorMessage = "Username is required")]
		public string? Username { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string? Mail { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
		public string? ConfirmPassword { get; set; }

	}
}
