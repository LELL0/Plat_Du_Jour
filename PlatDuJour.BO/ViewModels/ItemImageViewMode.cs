using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public  class ItemImageViewModel
    {
        public int ImageId { get; set; }
        [DataType(DataType.Text)]
        [StringLength(450)]
        public string ImageTag { get; set; }
        public DateTime? CreatedDate { get; set; }
        [DataType(DataType.ImageUrl)]
        [StringLength(450)]
        public string ImageUrl { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int ImageOrder { get; set; }
        [Required]
        public bool Active { get; set; }

        public IFormFile FormFile { get; set; }
    }
}