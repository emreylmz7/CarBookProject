using CarBookProject.Dto.Dtos.Car;
using CarBookProject.Dto.Dtos.CarFeature;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.CarViewComponents
{
    public class _CarDetailCarFeaturesSectionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarDetailCarFeaturesSectionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
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
    }
}
