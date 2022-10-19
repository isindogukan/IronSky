using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class TopSellingProductsModel
    {
        public List<ProductImagesCustomModel> All { get; set; }
        public List<ProductImagesCustomModel> Furniture { get; set; }
        public List<ProductImagesCustomModel> Decoration { get; set; }
        public List<ProductImagesCustomModel> Lighting { get; set; }
    }
}
