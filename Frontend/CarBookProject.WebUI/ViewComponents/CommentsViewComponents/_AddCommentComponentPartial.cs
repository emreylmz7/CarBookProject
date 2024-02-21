using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CommentsViewComponents
{
    public class _AddCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
