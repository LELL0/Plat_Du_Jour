using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class IngredientItem
    {
        [Key]
        public int ItemIngredientId { get; set; }
        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public decimal? Quantity { get; set; }
        [StringLength(50)]
        public string Unit { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Item Item { get; set; }
    }
}
