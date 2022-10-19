using Business.Helpers;
using IronSky.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents
{
    public class CartAreaViewComponent : ViewComponent
    {
        ICookieHelper _cookieHelper;

        public CartAreaViewComponent(ICookieHelper cookieHelper)
        {
            _cookieHelper = cookieHelper;
        }

        
        public IViewComponentResult Invoke()
        {
            var tokenKey = _cookieHelper.Get(CookieTypes.basket, Request);
            var basket = BasketHelper.GetMethods.Get(tokenKey);

            return View(basket);
        }
    }
}
