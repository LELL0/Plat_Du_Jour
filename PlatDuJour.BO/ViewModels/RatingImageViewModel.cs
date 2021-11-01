using Microsoft.AspNetCore.Http;
using PlatDuJour.BO.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public class RatingImageViewModel
    {
        public int ImageId { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Text)]
        [StringLength(300)]
        public string ImageTag { get; set; }
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensionFile(".jpg,.bmp,.PNG,.EPS,.gif,.TIFF,.tif,.jfif")]
        public IFormFile FormFile { get; set; }
        public int RatingId { get; set; }
    }
}