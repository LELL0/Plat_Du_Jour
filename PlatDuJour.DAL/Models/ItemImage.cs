using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class ItemImage
    {
        [Key]
        public int ImageId { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        public string ImageTag { get; set; }
        public DateTime? CreatedDate { get; set; }
        [DataType(DataType.ImageUrl)]
        [StringLength(450)]
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        [Required]
        public int ImageOrder { get; set; }
        [Required]
        public bool Active { get; set; }

        public virtual Item Item { get; set; }
    }
}
