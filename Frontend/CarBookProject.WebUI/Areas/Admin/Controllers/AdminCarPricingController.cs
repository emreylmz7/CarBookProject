using CarBookProject.Dto.Dtos.Banner;
using CarBookProject.Dto.Dtos.CarPricing;
using CarBookProject.Dto.Dtos.Pricing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarPricing")]
    public class AdminCarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CarPricingsDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> CarPricingsDetail(int id)
        {
            using var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync($"https://localhost:44335/api/CarPricings/GetCarPricingByCarId?id={id}").ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingDto>>(jsonData);
                ViewBag.CarName = values![1].Brand + " " + values[1].Model;
                return View(values);

            }

            

            return View();
        }

        [HttpPost("CarPricingUpdate")]
        public async Task<IActionResult> CarPricingUpdate(UpdateCarPricingDto updateCarPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44335/api/CarPricings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect($"/Admin/AdminCarPricing/CarPricingsDetail/{updateCarPricingDto.CarId}");
            }
            return View();
        }
    }
}
