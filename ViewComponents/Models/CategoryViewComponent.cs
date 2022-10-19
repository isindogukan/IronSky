using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class CategoryViewComponent : ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _categoryService.List();
            return View(result);
        }
    }
}
