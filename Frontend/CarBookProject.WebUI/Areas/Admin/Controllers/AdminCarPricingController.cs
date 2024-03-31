using CarBookProject.Dto.Dtos.Banner;
using CarBookProject.Dto.Dtos.CarPricing;
using CarBookProject.Dto.Dtos.Pricing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}
