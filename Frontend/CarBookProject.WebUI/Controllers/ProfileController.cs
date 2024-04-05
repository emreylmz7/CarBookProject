using CarBookProject.Dto.Dtos.Authentication;
using CarBookProject.Dto.Dtos.Feature;
using CarBookProject.Dto.Dtos.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

        public async Task<IActionResult> Reservations()
        {
            ViewBag.v1 = "Profile/Reservations";
            ViewBag.v2 = "My Reservations";
			decimal monthlyTotal = 0;
			var userId = User.Claims.FirstOrDefault(x => x.Type == "userId")!.Value.ToString();

            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")!.Value;
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
                    }
                    ViewBag.monthlyTotal = monthlyTotal.ToString();

                    return View(values);
                }

                return View();
            }
            return View();
        }
    }
}
