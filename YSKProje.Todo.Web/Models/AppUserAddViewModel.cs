using System.ComponentModel.DataAnnotations;

namespace YSKProje.Todo.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        [Display(Name ="Kullanıcı adı:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [DataType(DataType.Password)]
        [Display(Name ="Şifre:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrarı boş geçilemez.")]
        [Compare("Password",ErrorMessage ="Şifreler eşleşmemektedir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar:")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Geçersiz e-mail adresi.")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [Display(Name = "İsim:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş geçilemez.")]
        [Display(Name = "Soyisim:")]
        public string Surname { get; set; }
    }
}
