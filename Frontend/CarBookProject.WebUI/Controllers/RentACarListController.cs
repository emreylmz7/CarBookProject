using CarBookProject.Dto.Dtos.Location;
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
            var bookpickdate = ((DateTime)TempData["bookpickdate"]!).ToString("yyyy-MM-dd");
            var bookoffdate = ((DateTime)TempData["bookoffdate"]!).ToString("yyyy-MM-dd");
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
            ViewBag.Id = id.ToString();

            return View();
        }

        [HttpPost]
        public IActionResult Index(string locationId, string DropOffLocationId, string bookpickdate, string bookoffdate, string timepick, string timedrop)
        {
            TempData["locationId"] = locationId;
            TempData["DropOffLocationId"] = DropOffLocationId;
            TempData["bookpickdate"] = bookpickdate;
            TempData["bookoffdate"] = bookoffdate;
            TempData["timepick"] = timepick;
            TempData["timedrop"] = timedrop;
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
