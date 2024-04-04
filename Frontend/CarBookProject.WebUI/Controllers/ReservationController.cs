using CarBookProject.Dto.Dtos.Car;
using CarBookProject.Dto.Dtos.Location;
using CarBookProject.Dto.Dtos.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Car Rental";
            ViewBag.v2 = "Car Reservation Form";
            ViewBag.v3 = id;
            ViewBag.AppUserId = User.Claims.FirstOrDefault(x => x.Type == "userId")!.Value.ToString();

            ViewBag.CarId = TempData["carId"];
            ViewBag.PickupLocationId = TempData["pickUpLocationId"];
            ViewBag.DropOffLocationId = TempData["dropOffLocationId"];
            ViewBag.PickupDate = TempData["bookpickdate"];
            ViewBag.DropOffDate = TempData["bookoffdate"];

            //Car
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44335/api/Cars/GetCarWithBrand");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData2);
            var Car = values2!.Where(x => x.CarId == id).FirstOrDefault();
            ViewBag.BrandName = Car!.BrandName;
            ViewBag.CarModel = Car.Model;
            ViewBag.Transmission = Car.TransmissionType;
            ViewBag.Fuel = Car.Fuel;


            // Locations
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44335/api/RentACars/GetRentACarLocationListByCarId?carId={id}&available=true");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> pickUplocations = values!.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString(),
            }).ToList();

            ViewBag.Locations = pickUplocations;

            // Drop-Off Locations
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44335/api/Locations");

            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData3);
            List<SelectListItem> dropOfflocations = values3!.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString(),
            }).ToList();

            ViewBag.DropOffLocations = dropOfflocations;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            if (!ModelState.IsValid)
            {
                // Model doğrulama başarısız oldu, kullanıcıya tekrar formu göster
                return View(createReservationDto);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44335/api/Reservations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

    }
}
