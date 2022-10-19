using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class PopUpAreaViewComponent:ViewComponent
    {
        public PopUpAreaViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
