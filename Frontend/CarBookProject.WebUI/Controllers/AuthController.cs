using CarBook.Domain.Entities;
using CarBookProject.Dto.Dtos.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = new AppUser
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                UserName = registerDto.Username,
                Email = registerDto.Mail,
            };

            var result = await _userManager.CreateAsync(user,registerDto.Password!);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");   
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
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginDto.Username!, loginDto.Password!, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
