using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.AppUserCommands;
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
        private readonly RoleManager<AppRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IAuthenticatedUserRepository authenticatedUserRepository, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _authenticatedUserRepository = authenticatedUserRepository;
            _roleManager = roleManager;
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
				UserName = model.Username,
				Email = model.Mail,
				Name = model.Name,
				Surname = model.Surname,
				RegistrationDate = DateTime.Now
			};

			var result = await _userManager.CreateAsync(user, model.Password!);
			if (result.Succeeded)
			{
                string defaultRole = "User";

                if (!await _roleManager.RoleExistsAsync(defaultRole))
                {
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = defaultRole,
                    });
                }

                await _userManager.AddToRoleAsync(user, defaultRole);

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
				return Ok(new { token = GenerateJWT(user)});
			}
			return Unauthorized();
		}

		[HttpGet("AccountInfo")]
		public IActionResult AccountInfo()
		{
			var accountInfos = new AccountInfoQueryResult()
			{
				UserId = _authenticatedUserRepository.UserId,
				Username = _authenticatedUserRepository.Username,
				Email = _authenticatedUserRepository.Email,
				Name = _authenticatedUserRepository.Name,
				Surname = _authenticatedUserRepository.Surname,
                PhoneNumber = _authenticatedUserRepository.PhoneNumber,
				DateOfBirth = _authenticatedUserRepository.DateOfBirth,
				Address = _authenticatedUserRepository.Address,
				RegistrationDate = _authenticatedUserRepository.RegistrationDate,
				Age = _authenticatedUserRepository.Age,
				LicenseIssuanceYear = _authenticatedUserRepository.LicenseIssuanceYear,
			};
			return Ok(accountInfos);
		}

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(UpdateAppUserCommand model)
        {

			var user = await _userManager.FindByIdAsync((model.Id).ToString());

            if (user == null)
            {
                return NotFound(new { message = "Kullanıcı bulunamadı" });
            }

			user.UserName = model.UserName;
            user.Name = model.Name ?? user.Name;
            user.Surname = model.Surname ?? user.Surname;
            user.Email = model.Email ?? user.Email;
            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;
            user.Address = model.Address ?? user.Address;
            user.DateOfBirth = model.DateOfBirth;
            user.ProfilePicture = model.ProfilePicture;
            user.Age = model.Age;
            user.LicenseIssuanceYear = model.LicenseIssuanceYear;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { message = "Kullanıcı başarıyla güncellendi" });
            }

            return BadRequest(result.Errors);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordResult model)
        {
            var user = await _userManager.FindByNameAsync(model.Username!);
            if (user == null)
            {
                return BadRequest(new { message = "Kullanıcı bulunamadı" });
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword!, model.NewPassword!);
            if (result.Succeeded)
            {
                return Ok(new { message = "Şifre başarıyla değiştirildi" });
            }

            return BadRequest(result.Errors);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest(new { message = "Kullanıcı bulunamadı" });
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { message = "Kullanıcı başarıyla silindi" });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Rol adı boş olamaz");
            }

            // Belirtilen rol zaten mevcutsa hata döndür
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                return Conflict("Belirtilen rol zaten mevcut");
            }

            // Rolü oluştur
            var role = new AppRole()
            {
                Name = roleName,
            };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok($"Rol '{roleName}' başarıyla oluşturuldu");
            }

            return BadRequest("Rol oluşturma işlemi başarısız");
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
						new Claim("Name", user.Name ?? ""),
						new Claim("Surname", user.Surname!),
						new Claim("Email", user.Email!),
						new Claim("PhoneNumber", user.PhoneNumber ?? ""),
						new Claim("UserName", user.UserName!),
						new Claim("Address", user.Address ?? ""),
						new Claim("DateOfBirth", user.DateOfBirth.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString()),
						new Claim("RegistrationDate", user.RegistrationDate.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString()),
						new Claim("Age", user.Age.ToString() ?? "18"),
						new Claim("LicenseIssuanceYear", user.LicenseIssuanceYear.ToString() ?? "0"),
						new Claim("IsActive", user.IsActive.ToString() ?? "true"),
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
