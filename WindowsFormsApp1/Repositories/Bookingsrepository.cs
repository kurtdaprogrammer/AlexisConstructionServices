using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Messages;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class Bookingsrepository
    {

        public List<Booking> GetBookings()  // Changed method name to GetBookings
        {
            var Bookinglist = new List<Booking>();

            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    var query = ALEXISMessages.Getbookings;
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Bookinglist.Add(new Booking
                                {
                                    BookingID = reader.GetInt32(0),
                                    ClientID = reader.GetInt32(1),
                                    BookingReference = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    BookingDate = reader.GetDateTime(3),
                                    TotalAmount = reader.GetDecimal(4),
                                    ClientName = reader.GetString(5) // Fetch the ClientName
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return Bookinglist;
        }
        public List<Booking> SearchBookings(string searchTerm)
        {
            var Bookinglist = new List<Booking>();

            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    var query = ALEXISMessages.Searchbooking;

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Bookinglist.Add(new Booking
                                {
                                    BookingID = reader.GetInt32(0),
                                    ClientID = reader.GetInt32(1),
                                    BookingReference = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    BookingDate = reader.GetDateTime(3),
                                    TotalAmount = reader.GetDecimal(4),
                                    ClientName = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return Bookinglist;
        }

        public Booking GetBooking(int bookingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.Getbooking;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", bookingID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Booking booking = new Booking
                                {
                                    BookingID = reader.GetInt32(0),
                                    ClientID = reader.GetInt32(1),
                                    BookingDate = reader.GetDateTime(2),
                                    TotalAmount = reader.GetDecimal(3),
                                    ClientName = reader.GetString(4) // Fetch the ClientName from the database
                                };

                                return booking;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return null;
        }


        public void CreateBooking(Booking booking)
        {
            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();

                    // Generate a unique BookingReference
                    string bookingReference = GenerateBookingReference();

                    string sql = ALEXISMessages.CreateBooking;

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", booking.ClientID);
                        command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                        command.Parameters.AddWithValue("@TotalAmount", booking.TotalAmount);
                        command.Parameters.AddWithValue("@BookingReference", bookingReference);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        // Helper method to generate a unique BookingReference
        private string GenerateBookingReference()
        {
            return "REF" + DateTime.Now.Ticks.ToString().Substring(10); // Simple example, customize as needed
        }

        public void DeleteBooking(int BookingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();

                    string sql = ALEXISMessages.DeleteBooking;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.Message);
            }
        }
        // Add the UpdateBooking method here
        public void UpdateBooking(Booking booking)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();

                    string sql = ALEXISMessages.UpdateBooking;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", booking.BookingID);  // Ensure the correct BookingID
                        command.Parameters.AddWithValue("@ClientID", booking.ClientID);
                        command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                        command.Parameters.AddWithValue("@TotalAmount", booking.TotalAmount);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public bool IsDateBooked(int clientId, DateTime bookingDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();

                    // Query to check if there is already a booking on the selected date for the specific client
                    string sql = ALEXISMessages.isdatebooked;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);
                        command.Parameters.AddWithValue("@BookingDate", bookingDate.Date); // Ensure we only check the date part

                        int bookingCount = (int)command.ExecuteScalar();

                        // If there's at least one booking, return true indicating the date is booked
                        return bookingCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;  // Return false in case of an error (you may want to handle the error differently)
            }
        }

    }
}
