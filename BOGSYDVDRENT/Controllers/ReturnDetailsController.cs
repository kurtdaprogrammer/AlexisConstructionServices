using BOGSYDVDRENT.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Controllers
{
    public class ReturnDetailsController
    {
        private readonly string _connectionString;
        public ReturnDetailsController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
        public void AddReturnDetail(int returnId, int videoId, int quantity, int daysLate, decimal penalty)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO ReturnDetails (ReturnID, VideoID, QuantityReturned, DaysLate, Penalty)
                    VALUES (@ReturnID, @VideoID, @QuantityReturned, @DaysLate, @Penalty);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReturnID", returnId);
                cmd.Parameters.AddWithValue("@VideoID", videoId);
                cmd.Parameters.AddWithValue("@QuantityReturned", quantity);
                cmd.Parameters.AddWithValue("@DaysLate", daysLate);
                cmd.Parameters.AddWithValue("@Penalty", penalty);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
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
    }
}
