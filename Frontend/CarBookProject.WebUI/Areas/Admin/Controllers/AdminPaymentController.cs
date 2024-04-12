using CarBookProject.Dto.Dtos.Payment;
using CarBookProject.Dto.Dtos.Reservation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminPayment")]
    public class AdminPaymentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPaymentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Payments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPaymentDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}