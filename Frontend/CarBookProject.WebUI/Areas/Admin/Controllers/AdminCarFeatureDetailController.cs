using CarBookProject.Dto.Dtos.Banner;
using CarBookProject.Dto.Dtos.Brand;
using CarBookProject.Dto.Dtos.CarFeature;
using CarBookProject.Dto.Dtos.Feature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/AdminCarFeatureDetail")]
	public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
		public async Task<IActionResult> Index(int id)
		{
            ViewBag.CarId = id;
            //Features
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync($"https://localhost:44335/api/Features/GetFeaturesNotInThisCar/" + id);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData2);
                var featureValues = values2!.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.FeatureId.ToString(),
                }).ToList();
                ViewBag.Features = featureValues;
            }

            //Features by Car Id
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44335/api/CarFeatures/GetCarFeatureByCarId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<UpdateCarFeatureDto> model)
        {
            foreach (var item in model)
            {
                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync($"https://localhost:44335/api/CarFeatures/{item.CarFeatureId}");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<UpdateCarFeatureDto>(jsonData2);
               
                var PreviousAvailable = values2!.Available;

                if (item.Available != PreviousAvailable)
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(item);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:44335/api/CarFeatures", stringContent);
                }
                
            }

            return RedirectToAction("Index", "AdminCar");
        }

        [HttpPost("AddFeature")]
        public async Task<IActionResult> AddFeature(CreateCarFeatureDto createCarFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44335/api/CarFeatures", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect($"/Admin/AdminCarFeatureDetail/Index/"+createCarFeatureDto.CarId);
            }
            return Redirect($"/Admin/AdminCarFeatureDetail/Index/" + createCarFeatureDto.CarId);

        }
    }
}
