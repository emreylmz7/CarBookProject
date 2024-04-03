using CarBookProject.Dto.Dtos.Authentication;
using CarBookProject.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarBookProject.WebUI.Controllers
{
	public class AuthController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public AuthController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(registerDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44335/api/Auth/Register", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
                return RedirectToAction("Login", "Auth");
			}
			return View();
		}


        [HttpGet]
        public IActionResult Login()
        {
            return View();
		}
		[HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
			var client = _httpClientFactory.CreateClient();
			var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:44335/api/Auth/Login", content);
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("accessToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.Now.AddDays(1),
                            IsPersistent = true,
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProps);
                        return RedirectToAction("Index", "Default");
                    }
                }
            }
			return View();
        }
    }
}
