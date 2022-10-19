using Business.Helpers;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class HeaderAreaViewComponent : ViewComponent
    {
        IUserService _userService;
        IUserTokenService _userTokenService;
        ICookieHelper _cookieHelper;
        
        public HeaderAreaViewComponent(IUserService userService, IUserTokenService userTokenService, ICookieHelper cookieHelper)
        {
            _userService = userService;
            _userTokenService = userTokenService;
            _cookieHelper = cookieHelper;
            
        }

        public IViewComponentResult Invoke()
        {
            var cookie = _cookieHelper.Get(CookieTypes.user, Request);

            var tokenDetail = _userTokenService.Get(cookie);

            if (cookie == null || tokenDetail == null)
            {
                ViewData["email"] = null;
            }
            else
            {
                ViewData["email"] = _userService.GetById(tokenDetail.UserId).Email;
            }
            return View();
             
        }
      
    }
}
