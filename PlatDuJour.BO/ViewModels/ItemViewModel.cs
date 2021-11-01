using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        [Required]
        public string ItemName { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        [Required]
        public string ItemNameAr { get; set; }
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
        public string UserId { get; set; }
    }
}