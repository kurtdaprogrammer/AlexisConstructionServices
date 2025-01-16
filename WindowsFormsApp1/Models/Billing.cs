using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Billing
    {
        public int BillingID { get; set; } // Primary Key
        public int BookingID { get; set; } // Foreign Key from Bookings Table
        public decimal AmountDue { get; set; } // Total amount due
        public decimal AmountPaid { get; set; } // Amount paid so far
        public string PaymentStatus { get; set; } // Status (Paid/Pending)
    }
}
