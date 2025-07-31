using BOGSYDVDRENT.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOGSYDVDRENT.Controllers
{
    public class Videos : IVideos
    {
        public int VideoID { get; set; }
        public required string Title { get; set; }
        public required string Category { get; set; } 
        public decimal RentalRate { get; set; }
        public int MaxRentalDays { get; set; }
        public int TotalQuantity { get; set; }
    }
    public class VideosController
    {
        private readonly string _connectionString;

        public VideosController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void AddVideo(Videos videos)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Videostb (Title, Category, RentalRate, MaxRentalDays, TotalQuantity)
                         VALUES (@Title, @Category, @RentalRate, @MaxRentalDays, @TotalQuantity)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", videos.Title);
                    cmd.Parameters.AddWithValue("@Category", videos.Category);
                    cmd.Parameters.AddWithValue("@RentalRate", videos.RentalRate);
                    cmd.Parameters.AddWithValue("@MaxRentalDays", videos.MaxRentalDays);
                    cmd.Parameters.AddWithValue("@TotalQuantity", videos.TotalQuantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<IVideos> GetVideos()
        {
            var videos = new List<IVideos>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT VideoID,Title, Category, RentalRate, MaxRentalDays, TotalQuantity FROM Videostb";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        videos.Add(new Videos
                        {
                            VideoID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Category = reader.GetString(2),
                            RentalRate = reader.GetDecimal(3),
                            MaxRentalDays = reader.GetInt32(4),
                            TotalQuantity = reader.GetInt32(5)
                        });
                    }
                }
            }
            return videos;
        }
        public void DeleteVideo(int videoID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Videostb WHERE VideoID = @VideoID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VideoID", videoID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void EditVideo(Videos video)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            UPDATE Videostb
            SET Title = @Title,
                Category = @Category,
                RentalRate = @RentalRate,
                MaxRentalDays = @MaxRentalDays,
                TotalQuantity = @TotalQuantity
            WHERE VideoID = @VideoID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", video.Title);
                    command.Parameters.AddWithValue("@Category", video.Category);
                    command.Parameters.AddWithValue("@RentalRate", video.RentalRate);
                    command.Parameters.AddWithValue("@MaxRentalDays", video.MaxRentalDays);
                    command.Parameters.AddWithValue("@TotalQuantity", video.TotalQuantity);
                    command.Parameters.AddWithValue("@VideoID", video.VideoID);

                    command.ExecuteNonQuery();
                }
            }
        }
        public Videos GetVideoByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Videostb WHERE VideoID = @VideoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VideoID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Videos
                            {
                                VideoID = (int)reader["VideoID"],
                                Title = reader["Title"].ToString(),
                                Category = reader["Category"].ToString(),
                                RentalRate = (decimal)reader["RentalRate"],
                                MaxRentalDays = (int)reader["MaxRentalDays"],
                                TotalQuantity = (int)reader["TotalQuantity"]
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
