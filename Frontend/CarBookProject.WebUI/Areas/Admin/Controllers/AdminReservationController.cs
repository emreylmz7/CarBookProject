using CarBookProject.Dto.Dtos; // Assuming Dto.Dtos namespace contains ReservationDto
using CarBookProject.Dto.Dtos.Invoice;
using CarBookProject.Dto.Dtos.Reservation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Reservations/GetReservationsWithInfo");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationWithInfoDto>>(jsonData);
                return View(values);
            }
            return View();

        }

        //[Route("CreateReservation")]
        //[HttpGet]
        //public IActionResult CreateReservation()
        //{
        //    return View();
        //}

        //[Route("CreateReservation")]
        //[HttpPost]
        //public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createReservationDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:44335/api/Reservations", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[Route("RemoveReservation/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> RemoveReservation(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync($"https://localhost:44335/api/Reservations/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[Route("UpdateReservation/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> UpdateReservation(int id)
        //{
        //    using var client = _httpClientFactory.CreateClient();
        //    using var responseMessage = await client.GetAsync($"https://localhost:44335/api/Reservations/{id}").ConfigureAwait(false);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var values = JsonConvert.DeserializeObject<UpdateReservationDto>(jsonData);
        //        return View(values);
        //    }

        //    return View();
        //}

        //[Route("UpdateReservation/{id}")]
        //[HttpPost]
        //public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateReservationDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("https://localhost:44335/api/Reservations", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
        //    }
        //    return View();
        //}
    }
}
