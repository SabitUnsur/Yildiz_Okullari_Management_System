using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email giriniz.")]
        [Required(ErrorMessage = "Email  alanı boş bırakılamaz")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; }


        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
