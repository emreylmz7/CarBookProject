using CarBookProject.Dto.Dtos.Blog;
using CarBookProject.Dto.Dtos.TagCloud;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailCloudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var blogResponse = await client.GetAsync($"https://localhost:44335/api/Blogs/" + id);
            var tagResponse = await client.GetAsync("https://localhost:44335/api/TagClouds");

            if (blogResponse.IsSuccessStatusCode && tagResponse.IsSuccessStatusCode)
            {
                var blogJsonData = await blogResponse.Content.ReadAsStringAsync();
                var tagJsonData = await tagResponse.Content.ReadAsStringAsync();

                var blogDto = JsonConvert.DeserializeObject<ResultBlogDto>(blogJsonData);
                var tagDtoList = JsonConvert.DeserializeObject<List<ResultTagCloudDto>>(tagJsonData);

                // Gelen blogun BlogId'sine sahip olan tagleri filtrele
                var filteredTags = tagDtoList!.Where(tag => tag.BlogId == blogDto!.BlogId).ToList();

                return View(filteredTags);
            }
            else
            {
                // Bir hata durumunda uygun bir şey dönülmeli
                return Content("Bir hata oluştu.");
            }
        }
    }
}
