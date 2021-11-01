using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO.ViewModels
{
    public class DailyPlateViewModel
    {
        public int DailyPlateId { get; set; }
        public DateTime Day { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime? DateTimeToBeReady { get; set; }
        public string Comments { get; set; }
    }
}
