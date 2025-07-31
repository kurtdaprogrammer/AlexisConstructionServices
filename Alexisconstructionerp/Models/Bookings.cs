using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexisconstructionerp.Models
{
    public enum BookingStatus
    {
        Pending,
        Completed,
        Cancelled
    }
    public interface IBookings
    {
        int Booking_ID { get; set; }
        int Client_ID { get; set; }
        DateTime Booking_Date { get; set; }
        string Status { get; set; }
        string? Remarks { get; set; }
    }
    public class BookingsView
    {
        public int Booking_ID { get; set; }
        public string Client_name { get; set; }
        public string Booking_Date { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
