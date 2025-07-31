using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Controllers
{
    public class ReportsController
    {
        private readonly string _connectionString;

        public ReportsController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public DataTable GetRentalReport(DateTime? startDate = null, DateTime? endDate = null, int? customerId = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT   ret.ReturnID, 
                            c.Name AS CustomerName, 
                            ret.ReturnDate, 
                            v.Title AS VideoTitle,
                            rd.Penalty
                        FROM Returns ret
                        INNER JOIN Rentalstb r ON ret.RentalID = r.RentalID
                        INNER JOIN Customerstb c ON r.CustomerID = c.CustomerID
                        INNER JOIN ReturnDetails rd ON ret.ReturnID = rd.ReturnID
                        INNER JOIN Videostb v ON rd.VideoID = v.VideoID
                        WHERE (@startDate IS NULL OR ret.ReturnDate >= @startDate)
                          AND (@endDate IS NULL OR ret.ReturnDate <= @endDate)
                          AND (@customerId IS NULL OR c.CustomerID = @customerId)
                        ORDER BY ret.ReturnDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", (object?)startDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@endDate", (object?)endDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@customerId", (object?)customerId ?? DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetReturnReport(DateTime? startDate = null, DateTime? endDate = null, int? customerId = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT  r.RentalID, 
                            c.Name AS CustomerName, 
                            r.RentalDate, 
                            v.Title AS VideoTitle, 
                            rd.Quantity
                        FROM Rentalstb r
                        INNER JOIN Customerstb c ON r.CustomerID = c.CustomerID
                        INNER JOIN RentalDetails rd ON r.RentalID = rd.RentalID
                        INNER JOIN Videostb v ON rd.VideoID = v.VideoID
                        WHERE (@startDate IS NULL OR r.RentalDate >= @startDate)
                          AND (@endDate IS NULL OR r.RentalDate <= @endDate)
                          AND (@customerId IS NULL OR c.CustomerID = @customerId)
                        ORDER BY r.RentalDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", (object?)startDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@endDate", (object?)endDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@customerId", (object?)customerId ?? DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetCustomerList()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT CustomerID, Name FROM Customerstb WHERE IsActive = 1 ORDER BY Name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
