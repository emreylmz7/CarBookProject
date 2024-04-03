using CarBookProject.Dto.Dtos.Car;
using CarBookProject.Dto.Dtos.Review;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.CarViewComponents
{
	public class _CarDetailReviewsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailReviewsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44335/api/Reviews/GetReviewsByCarId?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultReviewDto>>(jsonData);
				ViewBag.CommentCount = values!.Count();
				return View(values);
			}
			return View();
		}
	}
}
