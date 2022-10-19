using Business.Services;
using IronSky.ViewComponents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents
{
    public class ContainerFluidViewComponent:ViewComponent
    {
        IProductService _productService;

        public ContainerFluidViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        
        public IViewComponentResult Invoke()
        {
            var result = new ContainerFluidModel();
            result.MostPopular = _productService.ProductWithImages().OrderByDescending(x => x.Counter).Take(5).ToList();
            result.NewProducts = _productService.ProductWithImages().OrderByDescending(x => x.Id).Take(5).ToList();
            result.LastView = _productService.ProductWithImages().OrderBy(x => Guid.NewGuid()).Take(5).ToList();//farklı urun gelir
            return View(result);
        }
    }
}
