using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Billing
    {
        public int BillingID { get; set; }
        public int BookingID { get; set; }
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
        public string BillingReference { get; set; }
        public string BookingReference   { get; set; }
        public string ClientName { get; set; }
    }
}
