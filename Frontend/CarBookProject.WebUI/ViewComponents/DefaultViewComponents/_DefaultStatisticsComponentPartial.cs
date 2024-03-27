using CarBookProject.Dto.Dtos.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44335/api/Statistics");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
				return View(values);
			}
			return View();
		}
    }
}
