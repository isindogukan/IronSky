using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class BannerAreaViewComponent:ViewComponent
    {
        IBannerService _bannerService;

        public BannerAreaViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        
        public IViewComponentResult Invoke()
        {
            //var banner = _bannerService.GetBanner(id:1);
            var banners = _bannerService.GetBanners();

            return View(banners);
        }
    }
}
