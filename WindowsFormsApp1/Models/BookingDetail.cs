using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class BookingDetail
    {
        public int BookingID { get; set; }
        public string ClientName { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalAmount { get; private set; }
        public List<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();

        public void AddService(ServiceDetail serviceDetail)
        {
            ServiceDetails.Add(serviceDetail);
            TotalAmount += serviceDetail.TotalAmount;
        }

        public void RemoveService(ServiceDetail serviceDetail)
        {
            ServiceDetails.Remove(serviceDetail);
            TotalAmount -= serviceDetail.TotalAmount;
        }
    }

    public class ServiceDetail
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
