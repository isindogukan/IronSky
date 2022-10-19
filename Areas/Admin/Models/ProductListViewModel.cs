using Entities;
using System.Collections.Generic;

namespace IronSky.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
