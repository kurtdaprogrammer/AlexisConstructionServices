using BOGSYDVDRENT.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace BOGSYDVDRENT.Controllers
{
    public class RentalControl
    {
        public int RentalDetailID { get; set; }
        public int RentalID { get; set; }
        public int VideoID { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }

        public decimal Subtotal => Quantity * Rate;
    }

    public class RentalControllers
    {
        private readonly string _connectionString;

        public RentalControllers()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public int AddRental(int customerId, DateTime rentalDate, DateTime dueDate, decimal totalAmount)
        {
            int rentalId;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO Rentalstb (CustomerID, RentalDate, DueDate, TotalAmount)
                    VALUES (@CustomerID, @RentalDate, @DueDate, @TotalAmount);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@RentalDate", rentalDate);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                    rentalId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return rentalId;
        }

        public List<RentalDetailView> GetUnreturnedRentalsByCustomer(int customerId)
        {
            List<RentalDetailView> rentals = new List<RentalDetailView>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        rd.RentalDetailID,
                        rd.RentalID,
                        rd.VideoID,
                        v.Title AS VideoTitle,
                        rd.Quantity,
                        rd.Rate,
                        r.RentalDate,
                        r.DueDate
                    FROM RentalDetails rd
                    INNER JOIN Rentalstb r ON rd.RentalID = r.RentalID
                    INNER JOIN Videostb v ON rd.VideoID = v.VideoID
                    WHERE r.CustomerID = @CustomerID AND rd.Returned = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentals.Add(new RentalDetailView
                            {
                                RentalDetailID = (int)reader["RentalDetailID"],
                                RentalID = (int)reader["RentalID"],
                                VideoID = (int)reader["VideoID"],
                                VideoTitle = reader["VideoTitle"].ToString(),
                                Quantity = (int)reader["Quantity"],
                                Rate = (decimal)reader["Rate"],
                                RentalDate = (DateTime)reader["RentalDate"],
                                DueDate = (DateTime)reader["DueDate"]
                            });
                        }
                    }
                }
            }

            return rentals;
        }

        private void DeductVideoQuantity(SqlConnection conn, SqlTransaction transaction, int videoId, int quantity)
        {
            string updateQuery = @"
                UPDATE Videostb
                SET Quantity = Quantity - @Quantity
                WHERE VideoID = @VideoID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@VideoID", videoId);
                cmd.ExecuteNonQuery();
            }
        }

        private void AddVideoQuantity(SqlConnection conn, SqlTransaction transaction, int videoId, int quantity)
        {
            string updateQuery = @"
                UPDATE Videostb
                SET Quantity = Quantity + @Quantity
                WHERE VideoID = @VideoID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@VideoID", videoId);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddRentalDetails(int rentalId, List<RentalControl> rentalDetails)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    foreach (var detail in rentalDetails)
                    {
                        string insertDetailQuery = @"
                            INSERT INTO RentalDetails (RentalID, VideoID, Quantity, Rate, Returned)
                            VALUES (@RentalID, @VideoID, @Quantity, @Rate, 0)";

                        using (SqlCommand cmd = new SqlCommand(insertDetailQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@RentalID", rentalId);
                            cmd.Parameters.AddWithValue("@VideoID", detail.VideoID);
                            cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
                            cmd.Parameters.AddWithValue("@Rate", detail.Rate);
                            cmd.ExecuteNonQuery();
                        }

                        DeductVideoQuantity(conn, transaction, detail.VideoID, detail.Quantity);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error saving rental details: " + ex.Message);
                }
            }
        }

        public void MarkAsReturnedAndRestock(List<int> rentalDetailIds)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    foreach (int rentalDetailId in rentalDetailIds)
                    {
                        // 1. Get quantity and video ID
                        string selectQuery = @"
                            SELECT VideoID, Quantity
                            FROM RentalDetails
                            WHERE RentalDetailID = @RentalDetailID";

                        int videoId = 0;
                        int qty = 0;

                        using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn, transaction))
                        {
                            selectCmd.Parameters.AddWithValue("@RentalDetailID", rentalDetailId);
                            using (SqlDataReader reader = selectCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    videoId = (int)reader["VideoID"];
                                    qty = (int)reader["Quantity"];
                                }
                            }
                        }

                        // 2. Mark as returned
                        string updateRentalDetail = @"
                            UPDATE RentalDetails
                            SET Returned = 1
                            WHERE RentalDetailID = @RentalDetailID";

                        using (SqlCommand updateCmd = new SqlCommand(updateRentalDetail, conn, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@RentalDetailID", rentalDetailId);
                            updateCmd.ExecuteNonQuery();
                        }

                        // 3. Add back quantity
                        AddVideoQuantity(conn, transaction, videoId, qty);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error updating returns: " + ex.Message);
                }
            }
        }
    }
}
