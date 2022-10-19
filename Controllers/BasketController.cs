using Business.Helpers;
using Business.Services;
using IronSky.Helpers;
using IronSky.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.Controllers
{
    public class BasketController : Controller
    {
        ICookieHelper _cookieHelper;
        IProductService _productService;
        IProductImageService _productImageService;
        

        public BasketController(ICookieHelper cookieHelper, IProductService productService, IProductImageService productImageService)
        {
            _cookieHelper = cookieHelper;
            _productService = productService;
            _productImageService = productImageService;
        }

        public IActionResult Index()
        {
            var guidKey = GetGuid();
            var basketDetail = BasketHelper.GetMethods.Get(guidKey);
            
            BasketIndexViewModel model = new();
            model.Basket = basketDetail;
            return View(model);
        }
        public JsonResult AddBasket(int quantityData,int productIdData)
        {
            string basketGuid = null;
            var basketCookieValue = _cookieHelper.Get(CookieTypes.basket, Request);
            if (basketCookieValue == null)
            {
                basketGuid = Guid.NewGuid().ToString();
                _cookieHelper.Add(CookieTypes.basket, basketGuid, DateTime.Now.AddDays(50), Response);
            }
            else
            {
                basketGuid = basketCookieValue;
            }
            var product = _productService.Get(productIdData);
            var productImages = _productImageService.GetImages(productIdData);
            
           
            BasketHelper.GetMethods.AddProduct(new BasketProduct
            {
                Image=productImages.First().Name,
                ProductId = productIdData,
                Quantity = quantityData,
                Product = product
            }, 
            basketGuid, 0, quantityData);
            var products = BasketHelper.GetMethods.Get(basketGuid);
            var basketDetail = BasketHelper.GetMethods.GetBasketDetails(basketGuid);


            string basketHtml = $"<a onclick=\"location.href='/mybasket'\" class=\"dropdown-toggle\"role=\"button\"data-toggle=\"dropdown\"aria-haspopup=\"true\"aria-expanded=\"false\"data-display=\"static\"><div class=\"icon\"><i class=\"icon-shopping-cart\"></i><span class=\"cart-count\">{basketDetail.Item1}</span></div><p>Cart - <span class=\"cart-amunt\">{basketDetail.Item2}</span></p></a>";

            //basketHtml += $"<div class=\"dropdown-cart-products\">";
            //foreach (var item in products.BasketProducts)
            //{
            //    basketHtml += "<div class=\"product\">";
            //    basketHtml += "<div class=\"product-cart-details\">";
            //    basketHtml += "<h4 class=\"product-title\">";
            //    basketHtml += "<a href=\"product.html\">" + item.Product.Name + "</a>";
            //    basketHtml += "</h4>";
            //    basketHtml += "<span class=\"cart-product-info\">";
            //    basketHtml += "<span class=\"cart-product-qty\">1</span>";
            //    basketHtml += "x " + item.Product.Price + "";
            //    basketHtml += "</span>";
            //    basketHtml += "</span>";
            //    basketHtml += "</div>";
            //    basketHtml += "<figure class=\"product-image-container\">";
            //    basketHtml += "<a href=\"product.html\" class=\"product-image\">";
            //    basketHtml += "<img src=\"/images/products/cart/" + item.Image + "\" alt=\"product\">";
            //    basketHtml += "</a>";
            //    basketHtml += "</figure>";
            //    basketHtml += "<a href=\"#\" class=\"btn-remove\" title=\"Remove Product\"><i class=\"icon-close\"></i></a>";
            //    basketHtml += "</div>";
            //    basketHtml += "</div>";
            //    basketHtml += "<div class=\"dropdown-cart-total\">";
            //    basketHtml += "<span>Total</span>";
            //    basketHtml += "<span class=\"cart-total-price\">" + item.Quantity * item.Product.Price + "</span>";
            //    basketHtml += "</div>";
            //}
            //basketHtml += "<div class=\"dropdown-cart-action\">";
            //basketHtml += "<a href=\"#\" class=\"btn btn-primary\">View Cart</a>";
            //basketHtml += "<a href=\"#\" class=\"btn btn-outline-primary-2\"><span>Checkout</span><i class=\"icon-long-arrow-right\"></i></a>";
            //basketHtml += "</div>";
            //basketHtml += "</div>";

            return Json(basketHtml);
           
        }
        public JsonResult GetBasket()
        {            
            string basketGuid = null;   
            var basketCookieValue = _cookieHelper.Get(CookieTypes.basket, Request);
            if (basketCookieValue == null)
            {
                basketGuid = Guid.NewGuid().ToString()  ;
                _cookieHelper.Add(CookieTypes.basket, basketGuid, DateTime.Now.AddDays(50), Response);
            }   
            else
            {
                basketGuid = basketCookieValue;
            }

           
            var basketDetail = BasketHelper.GetMethods.GetBasketDetails(basketGuid);
            if (basketDetail == null)
            {
                return Json($"<a onclick=\"location.href='/mybasket'\" class=\"dropdown-toggle\"role=\"button\"data-toggle=\"dropdown\"aria-haspopup=\"true\"aria-expanded=\"false\"data-display=\"static\"><div class=\"icon\"><i class=\"icon-shopping-cart\"></i><span class=\"cart-count\">0</span></div><p>Cart</p></a>");

            }
            string basketHtml = $"<a onclick=\"location.href='/mybasket'\" class=\"dropdown-toggle\"role=\"button\"data-toggle=\"dropdown\"aria-haspopup=\"true\"aria-expanded=\"false\"data-display=\"static\"><div class=\"icon\"><i class=\"icon-shopping-cart\"></i><span class=\"cart-count\">{basketDetail.Item1}</span></div><p>Cart - <span class=\"cart-amunt\">{basketDetail.Item2}</span></p></a>";

           

            return Json(basketHtml);
        }
        public JsonResult GetProductBasket(int quantityData, int productIdData)
        {
            string basketGuid = null;
            var basketCookieValue = _cookieHelper.Get(CookieTypes.basket, Request);
            if (basketCookieValue == null)
            {
                basketGuid = Guid.NewGuid().ToString();
                _cookieHelper.Add(CookieTypes.basket, basketGuid, DateTime.Now.AddDays(30), Response);
            }
            else
            {
                basketGuid = basketCookieValue;
            }
            var product = _productService.Get(productIdData); // id getirtik sepete eklerken
            var productImages = _productImageService.GetImages(productIdData); // resim getirdik sepete eklerken

            BasketHelper.GetMethods.AddProduct(new BasketProduct
            {
                Image = productImages.First().Name,
                ProductId = productIdData,
                Quantity = quantityData,
                Product = product
            }, basketGuid, 0, quantityData);
            var products = BasketHelper.GetMethods.Get(basketGuid);
            var basketDetail = BasketHelper.GetMethods.GetBasketDetails(basketGuid);

            string basketHtml = $"<div class=\"dropdown-cart-products\">";
            foreach (var item in products.BasketProducts)
            {
                basketHtml += "<div class=\"product\">";
                basketHtml += "<div class=\"product-cart-details\">";
                basketHtml += "<h4 class=\"product-title\">";
                basketHtml += "<a href=\"#\">"+item.Product.Name+"</a>";
                basketHtml += "</h4>";
                basketHtml += "<span class=\"cart-product-info\">";
                basketHtml += "<span class=\"cart-product-qty\">1</span>";
                basketHtml += "x "+item.Product.Price+"";
                basketHtml += "</span>";
                basketHtml += "</span>";
                basketHtml += "</div>";
                basketHtml += "<figure class=\"product-image-container\">";
                basketHtml += "<a href=\"product.html\" class=\"product-image\">";
                basketHtml += "<img src=\"/images/products/cart/"+item.Image+"\" alt=\"product\">";
                basketHtml += "</a>";
                basketHtml += "</figure>";
                basketHtml += "<a href=\"#\" class=\"btn-remove\" title=\"Remove Product\"><i class=\"icon-close\"></i></a>";
                basketHtml += "</div>";
                basketHtml += "</div>";
                basketHtml += "<div class=\"dropdown-cart-total\">";
                basketHtml += "<span>Total</span>";
                basketHtml += "<span class=\"cart-total-price\">"+item.Quantity*item.Product.Price+"</span>";
                basketHtml += "</div>";
            }
            basketHtml += "<div class=\"dropdown-cart-action\">";
            basketHtml += "<a href=\"#\" class=\"btn btn-primary\">View Cart</a>";
            basketHtml += "<a href=\"#\" class=\"btn btn-outline-primary-2\"><span>Checkout</span><i class=\"icon-long-arrow-right\"></i></a>";
            basketHtml += "</div>";
            basketHtml += "</div>";
     

            return Json(basketHtml);
        }



        private string GetGuid()
        {
            string basketGuid = null;
            var basketCookieValue = _cookieHelper.Get(CookieTypes.basket, Request);
            if (basketCookieValue == null)
            {
                basketGuid = Guid.NewGuid().ToString();
                _cookieHelper.Add(CookieTypes.basket, basketGuid, DateTime.Now.AddDays(50), Response);
            }
            else
            {
                basketGuid = basketCookieValue;
            }
            return basketGuid;
        }
        public IActionResult Minus(int Id)
        {
            var token = _cookieHelper.Get(CookieTypes.basket, Request);
            var products = BasketHelper.GetMethods.Get(token);
            var product = products.BasketProducts.FirstOrDefault(p => p.ProductId == Id);
            if (product.Quantity == 1)
            {
                products.BasketProducts.Remove(product);
            }
            else
            {
                product.Quantity += -1;
            }
            return Redirect("/mybasket");

        }
        public IActionResult Plus(int Id)
        {
            var token = _cookieHelper.Get(CookieTypes.basket, Request);
            var products = BasketHelper.GetMethods.Get(token);
            var product = products.BasketProducts.FirstOrDefault(p => p.ProductId == Id);

            product.Quantity += 1;

            return Redirect("/mybasket");

        }
    }
}
