using CarBookProject.Dto.Dtos.DropOffLocation;
using CarBookProject.Dto.Dtos.Location;
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

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44335/api/DropOffLocations");

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultDropOffLocationDto>>(jsonData2);
            List<SelectListItem> dropOfflocations = values2!.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.DropOffLocationId.ToString(),
            }).ToList();

            ViewBag.DropOffLocations = dropOfflocations;

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
    }
}
