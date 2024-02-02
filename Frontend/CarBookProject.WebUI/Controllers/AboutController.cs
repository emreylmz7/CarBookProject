using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
