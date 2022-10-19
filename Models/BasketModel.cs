using  Entities;
using System.Collections.Generic;

namespace IronSky.Models
{
    public class BasketModel
    {
        public BasketModel()
        {
            BasketProducts = new List<BasketProduct>();
        }
        public int? UserId { get; set; }
        public string CookieCode { get; set; }
        public List<BasketProduct> BasketProducts { get; set; } 

    }
    public class BasketProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
