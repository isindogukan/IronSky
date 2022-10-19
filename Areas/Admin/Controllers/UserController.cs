using Microsoft.AspNetCore.Mvc;
using Entities;
using IronSky.Models;
using Business.Services;
using IronSky.Areas.Admin.Models;
using Business.Helpers;
using IronSky.Helpers;
using System;

namespace IronSky.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        IUserService _userService;
        IStringHelper _stringHelper;

        public UserController(IUserService userService, IStringHelper stringHelper)
        {
            _userService = userService;
            _stringHelper = stringHelper;
        }

        public IActionResult Index()
        {
            UserListViewModel model = new();
            model.List = _userService.List();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Add(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(new User()
                {
                    Email = model.Email,
                    Password = _stringHelper.ToMd5(model.Password),
                    IsAdmin = model.IsAdmin,
                    Status = true
                });
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)// id parametre olarak gelir /admin/user/edit/23
        {
            var user = _userService.GetById(id); // 23 kullanıcısı bilgileri
            UserAddViewModel userModel = new UserAddViewModel();//user bilgilerini modele doldurduk
            userModel.Email = user.Email;
            userModel.IsAdmin = user.IsAdmin;
            userModel.UserId = AESHash.AES_Encrypt(id.ToString()); // *******************************************************************
            return View(userModel); // editlenmek üzere view e gönderdik
        }
        [HttpPost]
        public IActionResult Edit(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Id = Convert.ToInt32(AESHash.AES_Decrypt(model.UserId)),//***************************************************************
                    Email = model.Email,
                    Password = _stringHelper.ToMd5(model.Password),
                    IsAdmin = model.IsAdmin,
                    Status = true //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                };
                _userService.Update(user);
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}
