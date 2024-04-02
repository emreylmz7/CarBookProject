using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Results.AppUserResults;
using CarBookProject.Application.Interfaces.AuthenticationInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IConfiguration _configuration;
		private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

		public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IAuthenticatedUserRepository authenticatedUserRepository)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
			_authenticatedUserRepository = authenticatedUserRepository;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register(GetAppUserQueryResult model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = new AppUser
			{
				UserName = model.UserName,
				Email = model.Email,
				Name = model.Name,
				Surname = model.Surname,
				DateOfBirth = model.DateOfBirth,
				Address = model.Address,
				ProfilePicture = model.ProfilePicture,
				RegistrationDate = model.RegistrationDate,
				Age = model.Age,
				LicenseIssuanceYear = model.LicenseIssuanceYear,
				IsActive = model.IsActive
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				return StatusCode(201);
			}

			return BadRequest(result.Errors);
		}


		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginAppUserResult model)
		{
			var user = await _userManager.FindByNameAsync(model.Username);
			if (user == null)
			{
				return BadRequest(new { message = "Kullanıcı adı Hatalı" });
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, true);
			if (result.Succeeded)
			{
				return Ok(new { token = GenerateJWT(user) });
			}
			return Unauthorized();
		}

		[HttpGet("AccountInfo")]
		public IActionResult AccountInfo()
		{
			var Username = _authenticatedUserRepository.Username;
			var Name = _authenticatedUserRepository.Name;
			var Surname = _authenticatedUserRepository.Surname;
			var DateOfBirth = _authenticatedUserRepository.DateOfBirth;
			var Address = _authenticatedUserRepository.Address;
			var RegistrationDate = _authenticatedUserRepository.RegistrationDate;
			var Age = _authenticatedUserRepository.Age;

			return Ok(new { Username, Name, Surname, DateOfBirth, Address, RegistrationDate,Age });
		}


		private object GenerateJWT(AppUser user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? "");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(
					new Claim[] {
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
						new Claim(ClaimTypes.Name, user.UserName ?? ""),
						new Claim("UserId", user.Id.ToString()),
						new Claim("Name", user.Name ?? ""),
						new Claim("Surname", user.Surname!),
						new Claim("Email", user.Email!),
						new Claim("UserName", user.UserName!),
						new Claim("DateOfBirth", user.DateOfBirth.ToString("yyyy-MM-dd")),
						new Claim("RegistrationDate", user.RegistrationDate.ToString("yyyy-MM-dd")),
						new Claim("Age", user.Age.ToString()),
						new Claim("LicenseIssuanceYear", user.LicenseIssuanceYear.ToString()),
						new Claim("IsActive", user.IsActive.ToString()),
					}
				),
				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
