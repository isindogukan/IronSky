using Business.Services;
using Entities;
using IronSky.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace IronSky.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductImageService _productImageService;
        public ProductController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        public IActionResult Index()
        {
            var product = _productService.GetAll();
            ProductListViewModel products = new();
            products.ProductImages = _productImageService.List();
            products.Products = product;

            return View(products);
        }
        public IActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                _productService.Add(new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Status = model.Status,
                    SeoName = model.SeoName,
                    Counter = model.Counter
                });
                 
                return RedirectToAction("Index");
            }
        }
    }
}
