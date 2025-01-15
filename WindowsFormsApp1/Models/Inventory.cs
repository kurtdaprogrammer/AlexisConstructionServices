using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Inventory
    {
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; } // Added for display purposes
        public int QuantityAvailable { get; set; }
    }
}
