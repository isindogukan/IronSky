using System.ComponentModel.DataAnnotations;

namespace IronSky.Models
{
    public class ContactViewModel
    {
        

        [Required(ErrorMessage = "Ad Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon Giriniz.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Konuyu Giriniz.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj Giriniz.")]
        public string Message { get; set; }
    }
}
