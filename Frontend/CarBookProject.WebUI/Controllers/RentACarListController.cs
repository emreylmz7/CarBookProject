using CarBookProject.Dto.Dtos.DropOffLocation;
using CarBookProject.Dto.Dtos.Location;
using CarBookProject.Dto.Dtos.RentACar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            // Location
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44335/api/Locations");

            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            var values4 = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData4);
            List<SelectListItem> pickUplocations = values4!.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString(),
            }).ToList();

            ViewBag.Locations = pickUplocations;

            //TempDatas

            var locationId = TempData["locationId"];
            var DropOffLocationId = TempData["DropOffLocationId"];
            var bookpickdate = TempData["bookpickdate"];
            var bookoffdate = TempData["bookoffdate"];
            var timepick = TempData["timepick"];
            var timedrop = TempData["timedrop"];

            ViewBag.v1 = "Search Results";
            ViewBag.v2 = "Search";
            ViewBag.LocationId = locationId;
            ViewBag.DropOffLocationId = DropOffLocationId;
            ViewBag.PickDate = bookpickdate;
            ViewBag.DropDate = bookoffdate;
            ViewBag.PickTime = timepick;
            ViewBag.DropTime = timedrop;

            id = int.Parse(locationId!.ToString()!);

            // Cars
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44335/api/RentACars?locationId={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string locationId, string DropOffLocationId, string book_pick_date, string book_off_date, string time_pick, string time_drop)
        {
            TempData["locationId"] = locationId;
            TempData["DropOffLocationId"] = DropOffLocationId;
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timedrop"] = time_drop;
            return RedirectToAction("Index", "RentACarList");
        }

        [HttpPost]
        public IActionResult GetForReservation(string carId, string pickupLocationId, string dropOffLocationId, string preferredPickupDate, string preferredDropOffDate)
        {
            TempData["carId"] = carId;
            TempData["pickUpLocationId"] = pickupLocationId;
            TempData["dropOffLocationId"] = dropOffLocationId;
            TempData["bookpickdate"] = preferredPickupDate;
            TempData["bookoffdate"] = preferredDropOffDate;
            return RedirectToAction("Index", "Reservation", new { id = int.Parse(carId.ToString()) });
        }

    }
}
