using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage ="Yüzdelik değer boş bırakılamaz")]
        [Range(0, 100, ErrorMessage = "Değer 0 ile 100 arasında olmalıdır.")]
        public int Percentage { get; set; }
    }
}
