using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientImages = new HashSet<IngredientImage>();
            IngredientItems = new HashSet<IngredientItem>();
        }
        [Key]
        public int IngredientId { get; set; }
        [DataType(DataType.Text)]
        [Required]
        [StringLength(450)]
        public string IngredientName { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string IngredientDescription { get; set; }
        [StringLength(500)]
        [DataType(DataType.Text)]
        public string IngredientHeader { get; set; }
        [StringLength(500)]
        [DataType(DataType.Text)]
        public string IngredientTitle { get; set; }

        public virtual ICollection<IngredientImage> IngredientImages { get; set; }
        public virtual ICollection<IngredientItem> IngredientItems { get; set; }
    }
}
