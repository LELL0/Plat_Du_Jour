using Microsoft.AspNetCore.Http;
using PlatDuJour.BO.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public class IngredientImageViewModel
    {
        public int ImageId { get; set; }

        [Required]
        public int IngredientId { get; set; }
        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }
        [Required]
        public int ImageOrder { get; set; }

        public bool Active { get; set; }
        [StringLength(450)]
        public string ImageTitle { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensionFile(".jpg,.bmp,.PNG,.EPS,.gif,.TIFF,.tif,.jfif")]
        public IFormFile FormFile { get; set; }
    }
}