using Microsoft.AspNetCore.Mvc;

namespace IronSky.Areas.Admin.ViewComponents
{
    public class ContentWrapperViewComponent : ViewComponent
    {
        public ContentWrapperViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
