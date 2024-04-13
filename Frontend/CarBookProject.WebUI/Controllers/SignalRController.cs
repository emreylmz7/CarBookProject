using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class SignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
