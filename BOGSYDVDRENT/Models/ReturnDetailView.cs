using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Models
{
    public class RentalDetailView 
    {
        public int RentalDetailID { get; set; }
        public int RentalID { get; set; }
        public int VideoID { get; set; }
        public string VideoTitle { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
    }

}
