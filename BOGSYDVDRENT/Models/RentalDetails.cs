using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Models
{
    public interface IRentalDetails

    {
        int RentalDetailID { get; set; }
        int RentalID { get; }
        int VideoID { get; set; }
        string Title { get; set; }
        int Quantity { get; set; }
        decimal Rate { get; set; }
       
    }
}
