using Business.Services;
using IronSky.ViewComponents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents
{
    public class TopSellingProductsAreaViewComponent:ViewComponent
    {
        IProductService _productService;

        public TopSellingProductsAreaViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var result = new TopSellingProductsModel();
            result.All = _productService.ProductWithImages().OrderByDescending(x => x.Counter).Take(14).ToList();//counter a gore sıralar
            result.Decoration = _productService.ProductWithImages().OrderByDescending(x => x.Id).Take(7).ToList(); //ID YE GORE GETİRİ
            result.Furniture = _productService.ProductWithImages().OrderBy(x => Guid.NewGuid()).Take(4).ToList();//farklı urun gelir
            result.Lighting= _productService.ProductWithImages().OrderBy(x => Guid.NewGuid()).Take(5).ToList();//farklı urun gelir
             
            return View(result);
        }
    }
}
