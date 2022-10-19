using Business.Helpers;
using Business.Services;
using IronSky.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IronSky.Controllers
{
    public class HomeController : Controller
    {
        ICookieHelper _cookieHelper;
        IUserService _userService;
        IUserTokenService _userTokenService;

        public HomeController(ICookieHelper cookieHelper, IUserService userService, IUserTokenService userTokenService)
        {
            _cookieHelper = cookieHelper;
            _userService = userService;
            _userTokenService = userTokenService;
        }

        public IActionResult Index()
        {
            return View();
        }   
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var login = _userService.Login(model.Email, model.Password);
                if (login == null)
                {
                    ModelState.AddModelError("LoginError", "Giriş Başarısız.");
                }
                else
                {
                    string guid = Guid.NewGuid().ToString();
                    _cookieHelper.Add(CookieTypes.user, guid, DateTime.Now.AddDays(10), Response);
                    _userTokenService.Add(guid, login.Id);
                    return RedirectToAction("Index", "Home");
                }
                 
            }
            else
            {

            }
            return View();
        }
        public IActionResult Logout()
        {

            _cookieHelper.Delete(CookieTypes.user, Response);
            return RedirectToAction("Index");

        }

    }
}
