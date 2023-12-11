using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Rol ismi boş bırakılamaz")]
        [Display(Name = "Role ismi :")]
        public string ?Name { get; set; } 
    }
}
