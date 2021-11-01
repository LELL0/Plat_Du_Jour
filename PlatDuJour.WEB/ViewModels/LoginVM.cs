using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningIdentity.ViewModels
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [StringLength(450)]
        [Key]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(26)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
