using Microsoft.AspNetCore.Mvc;

namespace IronSky.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class NavbarViewComponent : ViewComponent
    {
        public NavbarViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
