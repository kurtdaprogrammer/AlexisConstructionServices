using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexisconstructionerp.Models
{
    public interface IServiceTools
    {
        int ServiceTool_ID { get; set; }
        int Service_ID { get; set; }
        int Inventory_ID { get; set; }
        decimal Required_Qty { get; set; }
    }
    public class ServicesToolsView
    {
        public int ServiceTool_ID { get; set; }
        public string Service_Name { get; set; }
        public string Tool_Name { get; set; }
        public decimal Required_Qty { get; set; }
    }
}
