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

        public Booking(int bookingID, int clientID, DateTime bookingDate, decimal totalAmount)
        {
            BookingID = bookingID;
            ClientID = clientID;
            BookingDate = bookingDate;
            TotalAmount = totalAmount;  
        }

        public Booking() { }
    }
}
