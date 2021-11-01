using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningIdentity.ViewModels
{
    public class RegisterVM
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [StringLength(450)]
        public string Email { get; set; }

        [Required]
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(26)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(26)]
        [Compare(nameof(Password),ErrorMessage ="Password does not match this field!")]
        [Display(Name="Repeat Password")]
        public string ConfirmPassword { get; set; }
    }
}
