using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
