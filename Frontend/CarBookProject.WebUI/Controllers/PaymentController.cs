using CarBookProject.Dto.Dtos.Feature;
using CarBookProject.Dto.Dtos.Invoice;
using CarBookProject.Dto.Dtos.Payment;
using CarBookProject.Dto.Dtos.Reservation;
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
        public async Task<IActionResult> Index(int id)
		{
            using var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync($"https://localhost:44335/api/Reservations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var values = JsonConvert.DeserializeObject<ResultReservationDto>(jsonData);
                ViewBag.Amount = values!.TotalCost.ToString();
            }

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

        public async Task<IActionResult> Invoice(int id)
        {
            using var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync($"https://localhost:44335/api/Invoices/GetInvoicesByPaymentId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var values = JsonConvert.DeserializeObject<List<ResultInvoiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
