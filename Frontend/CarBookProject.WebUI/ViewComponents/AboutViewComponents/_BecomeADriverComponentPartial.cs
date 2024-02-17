using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.AboutViewComponents
{
	public class _BecomeADriverComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
