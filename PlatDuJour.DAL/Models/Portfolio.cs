using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class Portfolio
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        [Required]
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1000)]
        [DataType(DataType.Text)] 
        public string Address { get; set; }
        
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string Header { get; set; }
        
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [StringLength(450)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [StringLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string CellNumber { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
