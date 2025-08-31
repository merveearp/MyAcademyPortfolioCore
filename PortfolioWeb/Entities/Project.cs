using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [MinLength(5,ErrorMessage ="Proje Adı en az 5 karakter olmalıdır.")]
        [MaxLength(50,ErrorMessage ="Proje Adı en fazla 50 karakter olmalıdır.")]
        [Required(ErrorMessage ="Proje Adı doldurulması zorunludur.")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Proje Açıklaması doldurulması zorunludur.")]
        public string Description{ get; set; }

        [Required(ErrorMessage = "Proje Görseli doldurulması zorunludur.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Projenin github linki doldurulması zorunludur.")]
        public string GithubUrl { get; set; }

        

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori Boş Bırakılamaz.")]
        public int CategoryId { get; set; }
        //Navigation Property
        public Category? Category { get; set; }
    }
}
