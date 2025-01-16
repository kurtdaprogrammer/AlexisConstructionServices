using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class BillingRepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlexisconstructionDB;Integrated Security=True";

        public List<Billing> GetBillings()
        {
            var billingList = new List<Billing>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Billings";
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
                                    PaymentStatus = reader.GetString(4)
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
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                INSERT INTO Billings (BookingID, AmountDue, AmountPaid, PaymentStatus)
                VALUES (@BookingID, @AmountDue, @AmountPaid, @PaymentStatus)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
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


    }
}
