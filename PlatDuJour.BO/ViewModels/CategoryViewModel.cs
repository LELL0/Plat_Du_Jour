using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO.ViewModels
{
    public class CategoryViewModel
    {
   
        public int CategoryId { get; set; }


        [StringLength(250)]
        [Required]
        [Display(Name ="Category")]
        public string CategoryName { get; set; }
        [StringLength(1000)]
        [Display(Name ="Description")]
        public string CategoryDescription { get; set; }
        //public int ParentId { get; set; }
        [StringLength(300)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Display(Name ="Upload Image")]
        public IFormFile FormFile { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Active { get; set; }
        [StringLength(250)]
        [Display(Name ="Header")]
        public string CategoryHeader { get; set; }
        [StringLength(250)]
        [Display(Name ="Title")]
        public string CategoryTitle { get; set; }
    }
}
