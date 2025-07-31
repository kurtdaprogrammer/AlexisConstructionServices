using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Models
{
    public interface ICustomers
    {
        int CustomerID { get; set; }
        string Name { get; set; }
        string ContactNumber { get; set; }
        string Address { get; set; }
    }
}
