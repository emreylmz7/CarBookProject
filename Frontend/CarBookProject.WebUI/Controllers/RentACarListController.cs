using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index(string pickupLocation, string dropoffLocation, string pickupDate, string dropoffDate, string pickupTime)
        {
            // Verileri kullanabilirsiniz
            ViewBag.PickupLocation = pickupLocation;
            ViewBag.DropoffLocation = dropoffLocation;
            ViewBag.PickupDate = pickupDate;
            ViewBag.DropoffDate = dropoffDate;
            ViewBag.PickupTime = pickupTime;

            return View();
        }
    }
}
