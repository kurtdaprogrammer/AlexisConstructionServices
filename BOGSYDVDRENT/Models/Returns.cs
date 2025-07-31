using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Models
{
    public class Returns
    {
        public int ReturnID { get; set; }
        public int RentalID { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalPenalty { get; set; }
    }
}
