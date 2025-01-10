using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class Bookingsrepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlexisconstructionDB;Integrated Security=True";

        public List<Booking> GetBookings()  // Changed method name to GetBookings
        {
            var Bookinglist = new List<Booking>();  // List should hold Booking objects

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                                SELECT b.BookingID, b.ClientID, b.BookingDate, b.TotalAmount, c.Name AS ClientName 
                                FROM Bookings b
                                JOIN Clients c ON b.ClientID = c.ClientID
                                ORDER BY b.BookingID DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Booking bookings = new Booking();
                                bookings.BookingID = reader.GetInt32(0);  
                                bookings.ClientID = reader.GetInt32(1);  
                                bookings.BookingDate = reader.GetDateTime(2);  
                                bookings.TotalAmount = reader.GetDecimal(3);
                                bookings.ClientName = reader.GetString(4);

                                Bookinglist.Add(bookings);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return Bookinglist;  // Return list of Booking objects
        }

        public Booking GetBooking(int BookingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Bookings WHERE BookingID=@BookingID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Booking bookings = new Booking();
                                bookings.BookingID = reader.GetInt32(0);
                                bookings.ClientID = reader.GetInt32(1);
                                bookings.BookingDate = reader.GetDateTime(2);
                                bookings.TotalAmount = reader.GetDecimal(3);

                                return bookings;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }

            return null;
        }

        public void CreateBooking(Booking booking)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Bookings (ClientID, BookingDate, TotalAmount) VALUES (@ClientID, @BookingDate, @TotalAmount);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", booking.ClientID); 
                        command.Parameters.AddWithValue("@BookingDate", booking.BookingDate); 
                        command.Parameters.AddWithValue("@TotalAmount", booking.TotalAmount); 

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
        }


    }
}
