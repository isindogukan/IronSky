using Business.Helpers;
using Business.Services;
using Entities;
using IronSky.Helpers;
using IronSky.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IronSky.Controllers
{
    public class CheckOutController : Controller
    {
        IOrderService _orderService;
        ICookieHelper _cookieHelper;

        public CheckOutController(IOrderService orderService, ICookieHelper cookieHelper)
        {
            _orderService = orderService;
            _cookieHelper = cookieHelper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CheckoutViewModel model)
        {
            if (model == null)
            {
                return RedirectToAction("Home", "Index");

            }
            if (ModelState.IsValid)
            {
                Order ord = new Order();
                ord.Address = model.Address;
                ord.City = Convert.ToInt32(model.City);
                ord.Date = DateTime.Now;
                ord.FirstName = model.FirstName;
                ord.LastName = model.LastName;
                ord.Phone = model.Phone;
                var token = _cookieHelper.Get(CookieTypes.basket, Request);
                var basket = BasketHelper.GetMethods.GetBasketDetails(token);
                var orderJson = Newtonsoft.Json.JsonConvert.SerializeObject(basket);

                ord.OrderDetail = orderJson;// json db ye gönderildi.
                                            //Json
                 
                _orderService.Add(ord);
                return RedirectToAction("Index", "Basket");
            }
            return View();
        }
    }
}
