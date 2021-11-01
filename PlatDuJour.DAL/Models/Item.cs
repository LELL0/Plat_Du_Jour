using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class Item
    {
        public Item()
        {
            DailyPlates = new HashSet<DailyPlate>();
            IngredientItems = new HashSet<IngredientItem>();
            ItemImages = new HashSet<ItemImage>();
        }

        [Key]
        public int ItemId { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        [Required]
        public string ItemName { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        [Required]
        public string ItemNameAr { get; set; }
        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        public string ItemHeader { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        public string ItemTitle { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string ItemDescription { get; set; }
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<DailyPlate> DailyPlates { get; set; }
        public virtual ICollection<IngredientItem> IngredientItems { get; set; }
        public virtual ICollection<ItemImage> ItemImages { get; set; }
    }
}
