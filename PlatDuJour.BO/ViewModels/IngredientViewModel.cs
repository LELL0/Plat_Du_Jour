using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public class IngredientViewModel
    {
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
    }
}