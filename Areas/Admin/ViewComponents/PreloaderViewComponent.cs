using Microsoft.AspNetCore.Mvc;

namespace IronSky.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class PreloaderViewComponent : ViewComponent
    {
        public PreloaderViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
