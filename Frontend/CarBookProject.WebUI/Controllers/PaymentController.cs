using CarBookProject.Dto.Dtos.Payment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class PaymentController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;
        public PaymentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(int id)
		{
            ViewBag.ReservationId = id.ToString();
            ViewBag.AppUserId = User.Claims.FirstOrDefault(x => x.Type == "userId")!.Value.ToString();

            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(CreatePaymentDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44335/api/Payments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
