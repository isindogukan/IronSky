using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class MainAreaViewComponent :ViewComponent
    {
        private readonly IProductService _productService;
        

        public MainAreaViewComponent(IProductService productService )
        {
            _productService = productService;
            
        }
        public IViewComponentResult Invoke()
        {
           
            var product = _productService.ProductWithImages();
             
            return View(product);
            
        }
    }
}
