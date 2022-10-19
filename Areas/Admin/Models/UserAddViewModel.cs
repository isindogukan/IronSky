using Entities;//-------------------
using System.ComponentModel.DataAnnotations;

namespace IronSky.Areas.Admin.Models
{
    public class UserAddViewModel //----------------
    {
        public string UserId { get; set; } // editlenen kullanıcının Id si bilinmelidir.

        [Required(ErrorMessage ="Email Giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Giriniz")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
