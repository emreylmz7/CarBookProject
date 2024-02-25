using CarBookProject.Dto.Dtos.Blog;
using CarBookProject.Dto.Dtos.Comment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarBookProject.WebUI.ViewComponents.CommentsViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44335/api/Comments/GetCommentsByBlogId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                if (values != null)
                {
                    int commentCount = values.Count;
                    ViewBag.CommentCount = commentCount;
                }
                else 
                {
                    ViewBag.CommentCount = 0;
                }

                return View(values);
            }
            return View();
        }
    }
}
