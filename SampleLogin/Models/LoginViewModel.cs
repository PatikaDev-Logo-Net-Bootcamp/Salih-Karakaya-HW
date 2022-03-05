using System.ComponentModel.DataAnnotations;

namespace SampleLogin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Ad Boş Olamaz")]
        string Name { get; set; }

        [Required(ErrorMessage = "Soyad Boş Olamaz")]
        string LastName { get; set; }

        [Required(ErrorMessage = "Eposta Boş Olamaz")]
        [EmailAddress(ErrorMessage = "Eposta adresi hatalı")]
        string Email { get; set; }

        [Required(ErrorMessage = "Şifre Boş Olamaz")]
        [MinLength(8)]
        [RegularExpression(
            pattern: "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])", 
            ErrorMessage = "Parola en az bir küçük, bir büyük harf ve bir sayı içermelidir")]
        string Password { get; set; }
    }
}
