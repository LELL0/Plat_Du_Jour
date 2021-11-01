using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class RatingImage
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        public string ImageTag { get; set; }
        
        [ForeignKey(nameof(Rating))]
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
        
        //public virtual Order OrderIdRate { get; set; }
    }
}
