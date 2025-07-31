using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexisconstructionerp.Models
{
    public interface IInventory
    {
        int Inventory_ID { get; set; }
        string Tool_name { get; set; }
        decimal Tool_Qty { get; set; }

    }
}
