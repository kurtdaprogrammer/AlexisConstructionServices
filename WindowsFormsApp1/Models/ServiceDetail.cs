using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class ServiceDetails
    {
        public int ServiceIDs { get; set; }  // ServiceID specific to ServiceDetail
        public string ServiceNames { get; set; }
        public int Hourss { get; set; }
        public decimal Rates { get; set; }
        public decimal TotalAmounts { get; set; }

        public ServiceDetails(int serviceID, string serviceName, int hours, decimal rate)
        {
            ServiceIDs = serviceID;
            ServiceNames = serviceName;
            Hourss = hours;
            Rates = rate;
            TotalAmounts = rate * hours;
        }

        public ServiceDetails() { }
    }


}
