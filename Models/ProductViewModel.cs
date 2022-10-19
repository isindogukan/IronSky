using  Entities;
using System.Collections.Generic;

namespace IronSky.Models
{
    public class ProductViewModel
    {
        public Product ProductDetail { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
