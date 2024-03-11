using CarBookProject.Dto.Dtos.Pricing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminPricing")]
    public class AdminPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Pricings"); 
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData); 
                return View(values);
            }
            return View();
        }

        [Route("CreatePricing")]
        [HttpGet]
        public IActionResult CreatePricing()
        {
            return View();
        }

        [Route("CreatePricing")] 
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44335/api/Pricings", stringContent); 
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemovePricing/{id}")] 
        [HttpGet]
        public async Task<IActionResult> RemovePricing(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44335/api/Pricings/{id}"); 
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" }); 
            }
            return View();
        }

        [Route("UpdatePricing/{id}")] 
        [HttpGet]
        public async Task<IActionResult> UpdatePricing(int id) 
        {
            using var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync($"https://localhost:44335/api/Pricings/{id}").ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var values = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData); 
                return View(values);
            }

            return View();
        }

        [Route("UpdatePricing/{id}")] 
        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricingDto) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44335/api/Pricings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" }); 
            }
            return View();
        }
    }
}
