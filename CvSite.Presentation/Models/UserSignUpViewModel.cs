using System.ComponentModel.DataAnnotations;

namespace CvSite.Presentation.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Isim Soyisim")]
        [Required(ErrorMessage = "Isim Soyisim alani bos gecilemez")]       
        public string NameSurname { get; set; }

        [Display(Name = "Sifre")]
        [Required(ErrorMessage = "Sifre alani bos gecilemez")]
        public string Password { get; set; }


        [Display(Name = "Sifre Tekrar")]
        [Compare(nameof(Password),ErrorMessage = "Sifreler Uyusmuyor !")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Mail alani bos gecilemez")]
        public string Mail { get; set; }


        [Display(Name = "Kullanici Adi")]
        [Required(ErrorMessage = "Kullanici Adi alani bos gecilemez")]
        public string UserName { get; set; }

    }
}
