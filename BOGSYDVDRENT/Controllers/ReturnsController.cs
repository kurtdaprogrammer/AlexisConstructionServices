using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Controllers
{
    public class ReturnsController
    {
        private readonly string _connectionString;
        public ReturnsController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
        public int AddReturn(int rentalId, DateTime returnDate, decimal penalty)
        {
            int returnId;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = @"INSERT INTO Returns (RentalID, ReturnDate, TotalPenalty) 
                             OUTPUT INSERTED.ReturnID 
                             VALUES (@RentalID, @ReturnDate, @TotalPenalty)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalID", rentalId);
                    cmd.Parameters.AddWithValue("@ReturnDate", returnDate);
                    cmd.Parameters.AddWithValue("@TotalPenalty", penalty);
                    returnId = (int)cmd.ExecuteScalar();
                }
            }
            return returnId;
        }
        public void AddReturnDetail(int returnId, int rentalDetailId, int videoId, int qty, int daysLate, decimal penalty)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = @"INSERT INTO ReturnDetails 
                    (ReturnID, RentalDetailID, VideoID, QuantityReturned, DaysLate, Penalty) 
                    VALUES (@ReturnID, @RentalDetailID, @VideoID, @Quantity, @DaysLate, @Penalty)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReturnID", returnId);
                    cmd.Parameters.AddWithValue("@RentalDetailID", rentalDetailId);
                    cmd.Parameters.AddWithValue("@VideoID", videoId);
                    cmd.Parameters.AddWithValue("@Quantity", qty);
                    cmd.Parameters.AddWithValue("@DaysLate", daysLate);
                    cmd.Parameters.AddWithValue("@Penalty", penalty);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ProcessReturn(int rentalDetailId, DateTime returnDate, decimal ratePerDay)
        {
            int rentalId = GetRentalIdFromDetail(rentalDetailId);
            int returnId = AddReturn(rentalId, returnDate, 0);
            var detail = GetRentalDetailWithDueDate(rentalDetailId); 
            int daysLate = (returnDate.Date - detail.DueDate.Date).Days;

            if (daysLate < 0) daysLate = 0;        

            decimal penalty = daysLate * ratePerDay * detail.Quantity;
            AddReturnDetail(returnId, rentalDetailId, detail.VideoID, detail.Quantity, daysLate, penalty);     
            MarkRentalDetailAsReturned(rentalDetailId);
            UpdateTotalPenalty(returnId, penalty);
        }
        private int GetRentalIdFromDetail(int rentalDetailId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "SELECT RentalID FROM RentalDetails WHERE RentalDetailID = @RentalDetailID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalDetailID", rentalDetailId);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        private (int VideoID, int Quantity, decimal Rate) GetRentalDetailById(int rentalDetailId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = @"SELECT VideoID, Quantity, Rate FROM RentalDetails 
                          WHERE RentalDetailID = @RentalDetailID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalDetailID", rentalDetailId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                VideoID: (int)reader["VideoID"],
                                Quantity: (int)reader["Quantity"],
                                Rate: (decimal)reader["Rate"]
                            );
                        }
                        else throw new Exception("Rental detail not found.");
                    }
                }
            }
        }
        private void MarkRentalDetailAsReturned(int rentalDetailId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "UPDATE RentalDetails SET Returned = 1 WHERE RentalDetailID = @RentalDetailID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalDetailID", rentalDetailId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private (int VideoID, int Quantity, DateTime DueDate) GetRentalDetailWithDueDate(int rentalDetailId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = @"SELECT rd.VideoID, rd.Quantity, r.DueDate 
                      FROM RentalDetails rd
                      INNER JOIN Rentalstb r ON rd.RentalID = r.RentalID
                      WHERE rd.RentalDetailID = @RentalDetailID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalDetailID", rentalDetailId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                VideoID: (int)reader["VideoID"],
                                Quantity: (int)reader["Quantity"],
                                DueDate: (DateTime)reader["DueDate"]
                            );
                        }
                        else throw new Exception("Rental detail not found.");
                    }
                }
            }
        }
        private void UpdateTotalPenalty(int returnId, decimal penalty)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "UPDATE Returns SET TotalPenalty = @Penalty WHERE ReturnID = @ReturnID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Penalty", penalty);
                    cmd.Parameters.AddWithValue("@ReturnID", returnId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
