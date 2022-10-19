using Business.Helpers;
using Business.Services;
using Entities;
using IronSky.Helpers;
using IronSky.Models;
using Microsoft.AspNetCore.Mvc;

namespace IronSky.Controllers
{
    public class PagesController : Controller
    {
        IContactService _contactService;
        ICookieHelper _cookieHelper;
        public PagesController(IContactService contactService, ICookieHelper cookieHelper)
        {
            _contactService = contactService;
            _cookieHelper = cookieHelper;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            if (model == null)
            {
                return RedirectToAction("Home", "Index");

            }
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.Name = model.Name;
                contact.Email = model.Email;
                contact.Phone = model.Phone;
                contact.Subject = model.Subject;
                contact.Message= model.Message;              
                //var token = _cookieHelper.Get(CookieTypes.basket, Request);
                //var basket = BasketHelper.GetMethods.GetBasketDetails(token);
                //var orderJson = Newtonsoft.Json.JsonConvert.SerializeObject(basket);

                //contact.Message = orderJson;// json db ye gönderildi.
                //                            //Json

                _contactService.Add(contact);
                return RedirectToAction("Index", "Pages");
            }
            return View();
        }
     
    }
}
