using Business.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace IronSky.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.List();          
            return View(about);
             
        }
    }
}
