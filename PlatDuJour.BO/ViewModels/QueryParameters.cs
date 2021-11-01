using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.BO.ViewModels
{
    public class QueryParameters
    {

        public QueryParameters()
        {
            PageNumber = 0;
            Range = 10;
        }
        public string UserId { get; set; }

        public int Id { get; set; }

        public int Number { get; set; }

        public int PageNumber { get; set; }

        public int Range { get; set; }

        public string ReturnUrl { get; set; }

        public bool OrderByDesc { get; set; }

        public string FilterValue { get; set; }
    }
}
