using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email giriniz.")]
        [Required(ErrorMessage = "Email  alanı boş bırakılamaz")]
        [Display(Name = "Email :")]
        public string? Email { get; set; }
    }
}
