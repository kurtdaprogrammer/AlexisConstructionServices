using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Booking
    {
        private decimal _totalAmount;

        public int BookingID { get; set; }
        public int ClientID { get; set; }
        public string BookingReference { get; set; } = "DefaultReference";
        public DateTime BookingDate { get; set; }

        // Validate setting the TotalAmount field
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total Amount cannot be negative.");
                _totalAmount = value;
            }
        }

        public string ClientName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }

        public List<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();

        public Booking(int bookingID, int clientID, string bookingReference, DateTime bookingDate, decimal totalAmount)
        {
            BookingID = bookingID;
            ClientID = clientID;
            BookingReference = bookingReference; // Initialize BookingReference
            BookingDate = bookingDate;
            TotalAmount = totalAmount;
            ServiceDetails = new List<ServiceDetail>(); // Initialize the list
        }

        public void AddService(ServiceDetail serviceDetail)
        {
            // Ensure ServiceDetails list is initialized (if not already)
            if (ServiceDetails == null)
            {
                ServiceDetails = new List<ServiceDetail>();
            }

            ServiceDetails.Add(serviceDetail);
            TotalAmount += serviceDetail.TotalAmount;
        }

        public void RemoveService(ServiceDetail serviceDetail)
        {
            // Ensure ServiceDetails list is initialized (if not already)
            if (ServiceDetails == null)
            {
                ServiceDetails = new List<ServiceDetail>();
            }

            ServiceDetails.Remove(serviceDetail);
            TotalAmount -= serviceDetail.TotalAmount;
        }

        public Booking() { }
    }
}
