using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class DailyPlate
    {
        public DailyPlate()
        {
            //Orders = new HashSet<Order>();
        }

        [Key]
        public int DailyPlateId { get; set; }
        public DateTime Day { get; set; }
        

        [ForeignKey(nameof(Item))]
        [Required]
        public int ItemId { get; set; }
        
        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime? DateTimeToBeReady { get; set; }
        public string Comments { get; set; }

        public virtual Item Item { get; set; }
            

        public virtual ICollection<Rating> Ratings { get; set; }


    }
}
