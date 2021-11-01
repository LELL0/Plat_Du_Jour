using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class IngredientImage
    {
        [Key]
        public int ImageId { get; set; }
        [ForeignKey(nameof(Ingredient))]
        [Required]
        public int IngredientId { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }
        [Required]
        public int ImageOrder { get; set; }
        
        public bool Active { get; set; }
        [StringLength(450)]
        public string ImageTitle { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
