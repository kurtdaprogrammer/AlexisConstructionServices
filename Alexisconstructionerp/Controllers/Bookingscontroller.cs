using Alexisconstructionerp.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alexisconstructionerp.Controllers
{
    public class Bookings : IBookings
    {
        public int Booking_ID { get; set; }
        public int Client_ID { get; set; }
        public DateTime Booking_Date { get; set; }
        public string Status { get; set; }
        public string? Remarks { get; set; }
    }
    public class Bookingscontroller
    {
        private readonly string _connectionString;
        public Bookingscontroller()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public List<IBookings> GetBookings()
        {
            var bookings = new List<IBookings>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT 
                Booking_ID,
                Client_ID,
                Booking_Date,
                Status,
                Remarks
            FROM Bookings";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Bookings
                        {
                            Booking_ID = reader.GetInt32(0),
                            Client_ID = reader.GetInt32(1),
                            Booking_Date = reader.GetDateTime(2),
                            Status = reader.GetString(3),
                            Remarks = reader.GetString(4)
                        });
                    }
                }
            }
            return bookings;
        }


        public void AddBooking(Bookings bookings)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Bookings (Client_ID, Booking_Date, Status, Remarks)
                                 VALUES (@ClientID, @BookingDate, @Status, @Remarks)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientID", bookings.Client_ID);
                    cmd.Parameters.AddWithValue("@BookingDate", bookings.Booking_Date);
                    cmd.Parameters.AddWithValue("@Status", bookings.Status);
                    cmd.Parameters.AddWithValue("@Remarks", bookings.Remarks ?? string.Empty);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                }

            }
        }
        public DataTable GetBookingsWithClientName()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT 
                b.Booking_ID,
                c.Client_Name,
                b.Booking_Date,
                b.Status,
                b.Remarks
            FROM Bookings b
            INNER JOIN Clientstb c ON b.Client_ID = c.Client_ID
            ORDER BY b.Booking_ID DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

    }

}
