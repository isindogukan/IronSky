using Entities;
using System.Collections.Generic;

namespace  IronSky.Models
{
    public class HeaderMiddleBasketModel : Product
    {
        public List<ProductImagesCustomModel> ForBasket { get; set; }
    }
}
