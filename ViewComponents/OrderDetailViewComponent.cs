using Business.Helpers;
using IronSky.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IronSky.ViewComponents
{
    public class OrderDetailViewComponent : ViewComponent
    {
        ICookieHelper _cookieHelper;
        public OrderDetailViewComponent(ICookieHelper cookieHelper)
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
