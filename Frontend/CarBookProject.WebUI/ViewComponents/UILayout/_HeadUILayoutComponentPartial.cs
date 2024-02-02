using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.UILayout
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
