using CarBookProject.Dto.Dtos.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.CarViewComponents
{
	public class _CarDetailMainComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44335/api/Cars/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
