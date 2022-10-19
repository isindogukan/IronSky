using Microsoft.AspNetCore.Mvc;

namespace IronSky.Areas.Admin.ViewComponents
{
    public class ContentWrapperContainsPageContentViewComponent : ViewComponent
    {
        public ContentWrapperContainsPageContentViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
