using System.ComponentModel.DataAnnotations;

namespace YSKProje.Todo.Web.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [Display(Name = "Kullanıcı adı:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre:")]
        public string Password { get; set; }
    }
}
