using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Models
{
    public class RentalItem
    {
        public int VideoID { get; set; }
        public string VideoTitle { get; set; }
        public int Quantity { get; set; }
        public decimal RentalRate { get; set; }
        public decimal Subtotal => Quantity * RentalRate;

        public override bool Equals(object obj)
        {
            return obj is RentalItem item &&
                   VideoID == item.VideoID;
        }

        public override int GetHashCode()
        {
            return VideoID.GetHashCode();
        }
    }
}
