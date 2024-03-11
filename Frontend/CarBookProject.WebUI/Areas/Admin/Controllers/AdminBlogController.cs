using CarBookProject.Dto.Dtos.Author;
using CarBookProject.Dto.Dtos.Blog;
using CarBookProject.Dto.Dtos.Brand;
using CarBookProject.Dto.Dtos.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlog")]
    public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Blogs/GetAllBlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateBlog")]
        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                List<SelectListItem> categoryValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.CategoryId.ToString(),
                                                    }).ToList();
                ViewBag.CategoryValues = categoryValues;
            }

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44335/api/Authors");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData2);
                List<SelectListItem> authorValues = (from x in values2
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.AuthorId.ToString(),
                                                       }).ToList();
                ViewBag.AuthorValues = authorValues;
            }
            return View();
        }

        [Route("CreateBlog")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44335/api/Blogs", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            else 
            {
                var client3 = _httpClientFactory.CreateClient();
                var responseMessage3 = await client3.GetAsync("https://localhost:44335/api/Categories");
                if (responseMessage3.IsSuccessStatusCode)
                {
                    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                    var values3 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData3);
                    List<SelectListItem> categoryValues = (from x in values3
                                                           select new SelectListItem
                                                           {
                                                               Text = x.Name,
                                                               Value = x.CategoryId.ToString(),
                                                           }).ToList();
                    ViewBag.CategoryValues = categoryValues;
                }

                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync("https://localhost:44335/api/Authors");
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData2);
                    List<SelectListItem> authorValues = (from x in values2
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.AuthorId.ToString(),
                                                         }).ToList();
                    ViewBag.AuthorValues = authorValues;
                }
            }
            return View();
        }

        [Route("RemoveBlog/{id}")]
        [HttpGet]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44335/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateBlog/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44335/api/Categories");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData3);
                List<SelectListItem> categoryValues = (from x in values3
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.CategoryId.ToString(),
                                                       }).ToList();
                ViewBag.CategoryValues = categoryValues;
            }

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44335/api/Authors");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData2);
                List<SelectListItem> authorValues = (from x in values2
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.AuthorId.ToString(),
                                                     }).ToList();
                ViewBag.AuthorValues = authorValues;
            }

            using var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync($"https://localhost:44335/api/Blogs/{id}").ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var values = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateBlog/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44335/api/Blogs", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            else 
            {
                var client3 = _httpClientFactory.CreateClient();
                var responseMessage3 = await client3.GetAsync("https://localhost:44335/api/Categories");
                if (responseMessage3.IsSuccessStatusCode)
                {
                    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                    var values3 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData3);
                    List<SelectListItem> categoryValues = (from x in values3
                                                           select new SelectListItem
                                                           {
                                                               Text = x.Name,
                                                               Value = x.CategoryId.ToString(),
                                                           }).ToList();
                    ViewBag.CategoryValues = categoryValues;
                }

                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync("https://localhost:44335/api/Authors");
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var values2 = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData2);
                    List<SelectListItem> authorValues = (from x in values2
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.AuthorId.ToString(),
                                                         }).ToList();
                    ViewBag.AuthorValues = authorValues;
                }
            }
            return View();
        }

    }
}
