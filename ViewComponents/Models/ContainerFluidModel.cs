using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronSky.ViewComponents.Models
{
    public class ContainerFluidModel
    {
        public List<ProductImagesCustomModel> NewProducts { get; set; }
        public List<ProductImagesCustomModel> MostPopular { get; set; }
        public List<ProductImagesCustomModel> LastView { get; set; }
    }
}
