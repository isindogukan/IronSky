using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class SliderAreaViewComponent : ViewComponent
    {
        ISliderService _sliderService;

        public SliderAreaViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IViewComponentResult Invoke()
        {
            var sliders = _sliderService.List();
            return View(sliders);
        }
    }
}
