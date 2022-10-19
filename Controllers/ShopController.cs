using Business.Services;
using IronSky.Models;
using Microsoft.AspNetCore.Mvc;

namespace IronSky.Controllers
{
    public class ShopController : Controller
    {
        ICategoryService _categoryService;
        IProductService _productService;

        public ShopController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index(int? page)
        {
            //var category = _categoryService.GetCategory();

            var products = _productService.GetCategoryProducts(page);

            ShopViewModel model = new()
            {
                Products = products,
                CurrentPage = page ?? 1, // ?? page null ise 1 değerini CurrentPage e ata değilse page değerini ata
                TotalPage = _productService.TotalPage(12), // buuuuuuuuuuuuuu >>>>>
                CategoryName = "" // kategori name 
            };

            return View(model);
      
        }
    }
}
