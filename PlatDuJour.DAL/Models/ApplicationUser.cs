using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Please do not exceed 200 characters!")]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        //public virtual ICollection<DailyPlate> DailyPlates { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }


    }
}
