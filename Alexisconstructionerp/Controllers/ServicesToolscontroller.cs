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
    public class ServicesTools : IServiceTools
    {
        public int ServiceTool_ID { get; set; }
        public int Service_ID { get; set; }
        public int Inventory_ID { get; set; }
        public decimal Required_Qty { get; set; }
    }
    public class ServicesToolscontroller
    {
        private readonly string _connectionString;
        public ServicesToolscontroller()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public List<Alexisconstructionerp.Models.IServiceTools> GetServicesTools()
        {
            var servicestools = new List<Alexisconstructionerp.Models.IServiceTools>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT s.Service_Name,i.Tool_Name,st.Required_Qty FROM ServiceTools st JOIN Services s ON s.Service_ID = st.Service_ID JOIN Inventory i ON i.Inventory_ID = st.Inventory_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        servicestools.Add(new ServicesTools
                        {
                            ServiceTool_ID = reader.GetInt32(0),
                            Service_ID = reader.GetInt32(1),
                            Inventory_ID = reader.GetInt32(2),
                            Required_Qty = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return servicestools;
        }
        public void InsertMapping(int serviceId, int toolId, int quantity)
        {
            if (serviceId <= 0 || toolId <= 0 || quantity <=0)
            {
                MessageBox.Show("Service Mapping is incomplete because there are missing values.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string query = "INSERT INTO ServiceTools (Service_ID, Inventory_ID, Required_Qty) VALUES (@serviceId, @toolId, @quantity)";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@serviceId", serviceId);
                    cmd.Parameters.AddWithValue("@toolId", toolId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
                
        }
        public List<ServicesToolsView> GetServicesToolsView()
        {
            var result = new List<ServicesToolsView>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT 
                                    st.ServiceTool_ID, 
                                    s.Service_Name, 
                                    i.Tool_Name, 
                                    st.Required_Qty 
                                FROM ServiceTools st
                                JOIN Services s ON s.Service_ID = st.Service_ID
                                JOIN Inventory i ON i.Inventory_ID = st.Inventory_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ServicesToolsView
                        {
                            ServiceTool_ID = reader.GetInt32(0),
                            Service_Name = reader.GetString(1),
                            Tool_Name = reader.GetString(2),
                            Required_Qty = reader.GetDecimal(3)
                        });
                    }
                }
            }

            return result;
        }
        public void RemoveServiceTools(int ServiceTool_ID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM ServiceTools WHERE ServiceTool_ID = @ServiceTool_ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceTool_ID", ServiceTool_ID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
