using CarBookProject.Dto.Dtos.AppUser;
using CarBookProject.Dto.Dtos.Authentication;
using CarBookProject.Dto.Dtos.Reservation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public ProfileController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Profile";
			ViewBag.v2 = "My Profile";

			var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")!.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				var responseMessage = await client.GetAsync("https://localhost:44335/api/Auth/AccountInfo");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<AccountProfileDto>(jsonData);
					return View(values);
				}
			}
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(UpdateAppUserDto updateAppUserDto)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "userId")!.Value;
            updateAppUserDto.Id = Convert.ToInt32(userId);

            updateAppUserDto.Age = DateTime.Today.Year - updateAppUserDto.DateOfBirth.Year;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAppUserDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44335/api/Auth/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Profile");
            }
            return View();
        }

        public async Task<IActionResult> Reservations()
        {
            ViewBag.v1 = "Profile/Reservations";
            ViewBag.v2 = "My Reservations";
            decimal monthlyTotal = 0;
            DateTime earliestPickupDate = DateTime.MaxValue;

            var userId = User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value.ToString();
            ViewBag.UserId = userId;

            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync($"https://localhost:44335/api/Reservations/GetReservationByUserId?id={userId}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultReservationsByUserIdDto>>(jsonData);

                    foreach (var item in values!)
                    {
                        monthlyTotal += item.TotalCost;
                        if (item.PreferredPickupDate > DateTime.Now)
                        {
                            if (item.PreferredPickupDate < earliestPickupDate)
                            {
                                earliestPickupDate = item.PreferredPickupDate;
                            }
                        }
                    }

                    if (earliestPickupDate == DateTime.MaxValue)
                    {
                        ViewBag.EarliestPickupDate = "No Rental Upcoming";
                    }
                    else
                    {
                        ViewBag.EarliestPickupDate = ((DateTime)earliestPickupDate!).ToString("dd MMMM");
                    }

                    ViewBag.monthlyTotal = monthlyTotal.ToString();
                    return View(values);
                }
            }

            return View();
        }

        public async Task<IActionResult> Reservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44335/api/Reservations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var values = JsonConvert.DeserializeObject<ResutlReservationByIdDto>(jsonData);
                return View(values);
            }

            return RedirectToAction("Reservations","Profile");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44335/api/Reservations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Reservations", "Profile");
            }
            return RedirectToAction("Reservations", "Profile");
        }

        public IActionResult Security()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Security(ChangePasswordDto model)
        {
   
            var userName = User.Claims.FirstOrDefault(x => x.Type == "UserName")!.Value;
            var changePasswordDto = new ChangePasswordApiDto()
            {
                Username = userName,
                NewPassword = model.NewPassword,
                OldPassword = model.OldPassword,
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(changePasswordDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44335/api/Auth/ChangePassword", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount()
        {
            var userName = User.Claims.FirstOrDefault(x => x.Type == "UserName")!.Value.ToString();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44335/api/Auth/DeleteUser?username={userName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Default");
            }
            return View("Security", "Profile");
        }
    }
}
