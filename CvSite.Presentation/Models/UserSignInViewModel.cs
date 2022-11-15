using System.ComponentModel.DataAnnotations;

namespace CvSite.Presentation.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage = "Kullanici Adi bos gecilemez.")]
		public string userName { get; set; }

        [Required(ErrorMessage = "Sifre bos gecilemez.")]
        public string password { get; set; }
	}
}
