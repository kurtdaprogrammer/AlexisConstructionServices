using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexisconstructionerp.Models
{
    public interface IServices
    {
        int Service_ID { get; set; }
        string Service_Name { get; set; }
        decimal Hourly_Rate { get; set; }
    }
}
