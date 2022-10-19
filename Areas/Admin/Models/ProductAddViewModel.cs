using Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IronSky.Areas.Admin.Models
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Name Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price Required.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description Required.")]
        public string Description { get; set; }
        public bool Status { get; set; }
        public string SeoName { get; set; }
        public int Counter { get; set; }
    }
}
