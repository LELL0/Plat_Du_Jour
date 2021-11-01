using Microsoft.AspNetCore.Http;
using PlatDuJour.BO.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public  class PortfolioViewModel
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        [Required]
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1000)]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [StringLength(450)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [StringLength(450)]
        [DataType(DataType.Text)]
        public string Header { get; set; }

        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(450)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [StringLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string CellNumber { get; set; }

        [MaxFileSize(5*1024*1024)]
        [AllowedExtensionFile(".jpg,.bmp,.PNG,.EPS,.gif,.TIFF,.tif,.jfif")]
        public IFormFile FormFile { get; set; }
    }
}