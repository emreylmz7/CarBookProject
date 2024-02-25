using CarBookProject.Dto.Dtos.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.CarViewComponents
{
    public class _CarDetailRelatedCarsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarDetailRelatedCarsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Cars/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                var firstFiveValues = values!.Take(3).ToList();
                return View(firstFiveValues);
            }
            return View();
        }
    }
}
