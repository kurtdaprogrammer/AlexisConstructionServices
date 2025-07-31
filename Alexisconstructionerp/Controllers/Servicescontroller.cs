using Alexisconstructionerp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Alexisconstructionerp.Controllers
{
    public class Services : IServices
    {
        public int Service_ID { get; set; }
        public string  Service_Name { get; set; }
        public decimal Hourly_Rate { get; set; }
    }

     
    public class Servicescontroller
    {
        private readonly string _connectionString;
        public Servicescontroller()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void AddServices(Alexisconstructionerp.Models.IServices services)
        {
            if (string.IsNullOrWhiteSpace(services.Service_Name) || services.Hourly_Rate <= 0)
            {
                MessageBox.Show("Service name must not be empty and quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO SERVICES (Service_Name,Hourly_Rate) VALUES (@Service_Name,@Hourly_Rate)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Service_Name", services.Service_Name);
                        command.Parameters.AddWithValue("@Hourly_Rate", services.Hourly_Rate);
                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Service saved successfully!");
        }
        public List<Alexisconstructionerp.Models.IServices> GetServices()
        {
            var services = new List<Alexisconstructionerp.Models.IServices>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Service_ID,Service_Name, Hourly_Rate FROM Services";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        services.Add(new Services
                        {
                            Service_ID = reader.GetInt32(0),
                            Service_Name = reader.GetString(1),
                            Hourly_Rate = reader.GetDecimal(2),
                        });
                    }
                }
            }
            return services;
        }
        public void RemoveService(int Service_ID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Services WHERE Service_ID = @Service_ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Service_ID", Service_ID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void EditServices(Services services)
        {
            if (string.IsNullOrEmpty(services.Service_Name) || services.Hourly_Rate <= 0)
            {
                MessageBox.Show("There are empty fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Services 
                             SET Service_Name = @Service_Name, 
                                 Hourly_Rate = @Hourly_Rate
                             WHERE Service_ID = @Service_ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Service_Name", services.Service_Name.Trim());
                    command.Parameters.AddWithValue("@Hourly_Rate", services.Hourly_Rate);
                    command.Parameters.AddWithValue("@Service_ID", services.Service_ID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Service record was updated. Please check the Service ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }
    }

}
