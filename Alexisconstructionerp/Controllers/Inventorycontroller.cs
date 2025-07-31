using Alexisconstructionerp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexisconstructionerp.Controllers
{
    public class Inventory : IInventory
    {
        public int Inventory_ID { get; set; }
        public string Tool_name { get; set; }
        public decimal Tool_Qty { get; set; }
    }
    
    public class Inventorycontroller
    {
        private readonly string _connectionString;

        public Inventorycontroller()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AddInventory(Alexisconstructionerp.Models.IInventory inventory)
        {
            if (string.IsNullOrWhiteSpace(inventory.Tool_name) || inventory.Tool_Qty <= 0)
            {
                MessageBox.Show("Tool name must not be empty and quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Inventory (Tool_name,Tool_Qty) VALUES (@Tool_name,@Tool_qty)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Tool_name", inventory.Tool_name);
                        command.Parameters.AddWithValue("@Tool_qty", inventory.Tool_Qty);   
                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Inventory saved successfully!");
        }
        public List<Alexisconstructionerp.Models.IInventory> GetInventories()
        {
            var inventories = new List<Alexisconstructionerp.Models.IInventory>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Inventory_ID,Tool_name, Tool_Qty FROM Inventory";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventories.Add(new Inventory
                        {
                            Inventory_ID = reader.GetInt32(0),
                            Tool_name = reader.GetString(1),
                            Tool_Qty = reader.GetDecimal(2),
                        });
                    }
                }
            }
            return inventories;
        }

        public void DeleteInventory(int inventory_id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Inventory WHERE Inventory_ID = @Inventory_ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Inventory_ID", inventory_id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void EditInventory(Inventory inventory) {
            if (string.IsNullOrEmpty(inventory.Tool_name) || inventory.Tool_Qty <= 0)
            {
                MessageBox.Show("There are empty fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Inventory 
                             SET Tool_name = @Tool_name, 
                                 Tool_Qty = @Tool_Qty
                             WHERE Inventory_ID = @Inventory_ID";   
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tool_name", inventory.Tool_name.Trim());
                    command.Parameters.AddWithValue("@Tool_Qty", inventory.Tool_Qty);
                    command.Parameters.AddWithValue("@Inventory_ID", inventory.Inventory_ID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Inventory updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Inventory record was updated. Please check the Client ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }
    }
}
