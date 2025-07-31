using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Models
{
    public class ReturnDetail
    {
        public int ReturnDetailID { get; set; }
        public int ReturnID { get; set; }
        public int VideoID { get; set; }
        public int QuantityReturned { get; set; }
        public int DaysLate { get; set; }
        public decimal Penalty { get; set; }
    }
}
