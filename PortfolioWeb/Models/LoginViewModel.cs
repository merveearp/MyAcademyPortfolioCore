using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
        public string Password { get; set; }
    }
}
