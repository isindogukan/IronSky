using Entities;
using System.Collections.Generic;

namespace IronSky.Models
{
    public class ShopViewModel 
    {
        public List<CategoryProductsCustomModel> Products { get; set; }
        public int CurrentPage { get; set; }    
        public int TotalPage { get; set; }
        public string CategoryName { get; set; }    
        
    }
}
