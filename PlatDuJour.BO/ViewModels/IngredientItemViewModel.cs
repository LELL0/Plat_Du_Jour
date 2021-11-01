using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public  class IngredientItemViewModel
    {
        public int ItemIngredientId { get; set; }
        
        [Required]
        public int IngredientId { get; set; }
        
        [Required]
        public int ItemId { get; set; }
        public decimal? Quantity { get; set; }
        [StringLength(50)]
        public string Unit { get; set; }
    }
}