namespace PortfolioWeb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EditPasswordViewModel
    {
        [Display(Name = "Mevcut Şifre")]
        [Required(ErrorMessage = "Mevcut şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } 
        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Yeni şifre zorunludur.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Yeni şifre en az 6 karakter olmalı.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Yeni Şifre (Tekrar)")]
        [Required(ErrorMessage = "Yeni şifre tekrarı zorunludur.")]
        [Compare(nameof(NewPassword), ErrorMessage = "Yeni şifre ile tekrarı uyuşmuyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

}
