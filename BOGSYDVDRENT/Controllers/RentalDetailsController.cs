using BOGSYDVDRENT.Models;
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
    public class RentalDetailModel : IRentalDetails
    {
        public int RentalDetailID { get; set; }
        public int RentalID { get; set; }
        public int VideoID { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Subtotal => Quantity * Rate;
    }
    public class RentalDetailsController
    {
        private readonly string _connectionString;

        public RentalDetailsController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AddRentalDetail(int rentalId, int videoId, int quantity, decimal rate)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                INSERT INTO RentalDetails (RentalID, VideoID, Quantity, Rate)
                VALUES (@RentalID, @VideoID, @Quantity, @Rate)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalID", rentalId);
                    cmd.Parameters.AddWithValue("@VideoID", videoId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Rate", rate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
