using System.ComponentModel.DataAnnotations;
 

namespace IronSky.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Şehir Seçiniz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ad Giriniz.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad Giriniz.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Telefon Giriniz.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adres Giriniz.")]
        public string Address { get; set; }
    }
}
