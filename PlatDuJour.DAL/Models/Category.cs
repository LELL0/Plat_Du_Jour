using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        public int CategoryId { get; set; }
        [StringLength(250)]
        [Required]
        public string CategoryName { get; set; }
        [StringLength(1000)]
        public string CategoryDescription { get; set; }
        public Nullable<int> ParentId { get; set; }
        [StringLength(300)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Active { get; set; }
        [StringLength(250)]
        public string CategoryHeader { get; set; }
        [StringLength(250)]
        public string CategoryTitle { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
