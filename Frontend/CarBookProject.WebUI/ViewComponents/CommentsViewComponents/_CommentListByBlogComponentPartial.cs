using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CommentsViewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
