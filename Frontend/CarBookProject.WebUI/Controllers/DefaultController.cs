using CarBookProject.Dto.Dtos.DropOffLocation;
using CarBookProject.Dto.Dtos.Location;
using CarBookProject.Dto.Dtos.RentACar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> pickUplocations = values!.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString(),
            }).ToList();

            ViewBag.Locations = pickUplocations;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchRentACarDto model)
        {
            if (ModelState.IsValid)
            {
                TempData["locationId"] = model.LocationId;
                TempData["DropOffLocationId"] = model.DropOffLocationId;
                TempData["bookpickdate"] = model.BookPickDate.Date.ToString("yyyy-MM-dd");
                TempData["bookoffdate"] = model.BookOffDate.Date.ToString("yyyy-MM-dd");
                TempData["timepick"] = model.TimePick.ToString();
                TempData["timedrop"] = model.TimeDrop.ToString();

                return RedirectToAction("Index", "RentACarList");
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44335/api/Locations");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                List<SelectListItem> pickUplocations = values!.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationId.ToString(),
                }).ToList();

                ViewBag.Locations = pickUplocations;
                // Model doğrulama başarısız ise tekrar view'e dön
                return View(model);
            }
        }

    }
}
