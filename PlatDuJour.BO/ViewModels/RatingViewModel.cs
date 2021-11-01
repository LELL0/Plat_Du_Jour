using System;
using System.ComponentModel.DataAnnotations;

namespace PlatDuJour.BO.QueryFilter
{
    public class RatingViewModel
    {
        public int RatingId { get; set; }

        [Required]
        public string UserId { get; set; }
        
        [Required]
        public int DailyPlateId { get; set; }

        public DateTime RateDate { get; set; }

        public decimal RateValue { get; set; }
    }
}