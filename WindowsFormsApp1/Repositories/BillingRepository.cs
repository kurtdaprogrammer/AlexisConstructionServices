using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class BillingRepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlexisconstructionDB;Integrated Security=True";
        // Method to generate a unique BillingReference
        private string GenerateBillingReference()
        {
            return "BILL" + DateTime.Now.Ticks.ToString().Substring(10); // Example: "BILL" followed by a unique timestamp
        }

        public List<Billing> GetBillings()
        {
            var billingList = new List<Billing>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT BillingID, BookingID, AmountDue, AmountPaid, PaymentStatus, BillingReference FROM Billings";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Billing billing = new Billing
                                {
                                    BillingID = reader.GetInt32(0),
                                    BookingID = reader.GetInt32(1),
                                    AmountDue = reader.GetDecimal(2),
                                    AmountPaid = reader.GetDecimal(3),
                                    PaymentStatus = reader.GetString(4),
                                    BillingReference = reader.GetString(5)  // Ensure this line correctly maps the BillingReference
                                };
                                billingList.Add(billing);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return billingList;
        }

        public void CreateBilling(Billing billing)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Billings (BookingID, AmountDue, AmountPaid, PaymentStatus, BillingReference) " +
                               "VALUES (@BookingID, @AmountDue, @AmountPaid, @PaymentStatus, @BillingReference)";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingID", billing.BookingID);
                command.Parameters.AddWithValue("@AmountDue", billing.AmountDue);
                command.Parameters.AddWithValue("@AmountPaid", billing.AmountPaid);
                command.Parameters.AddWithValue("@PaymentStatus", billing.PaymentStatus);
                command.Parameters.AddWithValue("@BillingReference", billing.BillingReference); // Add BillingReference parameter

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateBilling(Billing billing)
        {
            try
            {
                // Automatically update PaymentStatus based on AmountPaid and AmountDue
                if (billing.AmountPaid >= billing.AmountDue)
                {
                    billing.PaymentStatus = "Paid";
                }
                else
                {
                    billing.PaymentStatus = "Pending";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
            UPDATE Billings
            SET BookingID = @BookingID, AmountDue = @AmountDue, AmountPaid = @AmountPaid, PaymentStatus = @PaymentStatus
            WHERE BillingID = @BillingID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BillingID", billing.BillingID);
                        command.Parameters.AddWithValue("@BookingID", billing.BookingID);
                        command.Parameters.AddWithValue("@AmountDue", billing.AmountDue);
                        command.Parameters.AddWithValue("@AmountPaid", billing.AmountPaid);
                        command.Parameters.AddWithValue("@PaymentStatus", billing.PaymentStatus);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public void DeleteBilling(int billingID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Billings WHERE BillingID=@BillingID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BillingID", billingID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        public Billing GetBillingByBookingID(int bookingID)
        {
            Billing billing = null;



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to get the billing details by BookingID
                string query = "SELECT BillingID, BookingID, AmountDue, AmountPaid, PaymentStatus FROM Billings WHERE BookingID = @BookingID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookingID", bookingID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        billing = new Billing
                        {
                            BillingID = reader.GetInt32(reader.GetOrdinal("BillingID")),
                            BookingID = reader.GetInt32(reader.GetOrdinal("BookingID")),
                            AmountDue = reader.GetDecimal(reader.GetOrdinal("AmountDue")),
                            AmountPaid = reader.GetDecimal(reader.GetOrdinal("AmountPaid")),
                            PaymentStatus = reader.GetString(reader.GetOrdinal("PaymentStatus"))
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving billing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return billing;
        }

    }
}
