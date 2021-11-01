using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser{get;set;}

        [ForeignKey(nameof(DailyPlate))]
        public int DailyPlateId { get; set; }

        public DailyPlate DailyPlate { get; set; }

        public DateTime RateDate { get; set; }

        public decimal RateValue { get; set; }

        public virtual ICollection<RatingImage> RatingImages { get; set; }


    }
}
