using Microsoft.AspNetCore.Mvc;

namespace IronSky.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class MainSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
