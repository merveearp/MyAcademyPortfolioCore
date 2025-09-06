using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Models
{
    public class ProfileEditViewModel
    {
         public int UserId { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "isim alanı boş bırakılamaz!")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz!")]
        public string LastName { get; set; }

    }
}
