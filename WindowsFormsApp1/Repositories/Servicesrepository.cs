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
    internal class Servicesrepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlexisconstructionDB;Integrated Security=True";

        public List<Service> GetServices() 
        {
            var serviceList = new List<Service>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Services ORDER BY ServiceID DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var service = new Service
                                {
                                    ServiceID = reader.GetInt32(0),
                                    ServiceName = reader.GetString(1),
                                    HourlyRate = reader.GetDecimal(2)
                                };
                                serviceList.Add(service);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }

            return serviceList;

        }

        public Service GetService(int ServiceID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Services WHERE ServiceID=@ServiceID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID); // Use the method parameter ServiceID
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var service = new Service
                                {
                                    ServiceID = reader.GetInt32(0),
                                    ServiceName = reader.GetString(1),
                                    HourlyRate = reader.GetDecimal(2)
                                };
                                return service;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }

            return null;
        }


        public void CreateService(Service service)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Services" +
                        "(ServiceName, HourlyRate) VALUES " +
                        "(@ServiceName, @HourlyRate);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                        command.Parameters.AddWithValue("@HourlyRate", service.HourlyRate);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
        }
        public void UpdateService(Service service)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Services " +
                                 "SET ServiceName=@ServiceName, HourlyRate=@HourlyRate " +
                                 "WHERE ServiceID=@ServiceID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                        command.Parameters.AddWithValue("@HourlyRate", service.HourlyRate);
                        command.Parameters.AddWithValue("@ServiceID", service.ServiceID);

                        //error checking
                        MessageBox.Show($"Updating ServiceID: {service.ServiceID}, ServiceName: {service.ServiceName}, HourlyRate: {service.HourlyRate}");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating service: " + ex.Message);
            }
        }
        public void DeleteService(int ServiceID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Services WHERE ServiceID=@ServiceID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.Message);
            }
        }


    }
}
