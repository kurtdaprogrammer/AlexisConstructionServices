using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Messages;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class InventoryRepository
    {

        public List<Inventory> GetInventories()
        {

            var inventoryList = new List<Inventory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.GetInventories;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Inventory inventory = new Inventory
                                {
                                    ToolID = reader.GetInt32(0),
                                    ToolName = reader.GetString(1),
                                    ServiceName = reader.GetString(2), // Fetch ServiceName
                                    QuantityAvailable = reader.GetInt32(3)
                                };

                                inventoryList.Add(inventory);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return inventoryList;
        }
        public Inventory GetInventory(int InventoryID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.GetInventory;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@InventoryID", InventoryID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Inventory inventory = new Inventory();
                                inventory.ToolID = reader.GetInt32(0);
                                inventory.ToolName = reader.GetString(1);
                                inventory.ServiceID = reader.GetInt32(2);
                                inventory.QuantityAvailable = reader.GetInt32(3);

                                return inventory;
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
        public void CreateTool(Inventory inventory)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.CreateTool;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ToolName", inventory.ToolName);
                        command.Parameters.AddWithValue("@ServiceID", inventory.ServiceID);
                        command.Parameters.AddWithValue("@QuantityAvailable", inventory.QuantityAvailable);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
        }

        public void DeleteInventory(int InventoryID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.DeleteTool;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ToolID", InventoryID);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            Console.WriteLine($"No rows found with ToolID: {InventoryID}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting inventory: {ex.Message}");
            }
        }

        public void UpdateTool(Inventory inventory)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();

                    string sql = ALEXISMessages.UpdateTool;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ToolID", inventory.ToolID);
                        command.Parameters.AddWithValue("@ToolName", inventory.ToolName);
                        command.Parameters.AddWithValue("@ServiceID", inventory.ServiceID);
                        command.Parameters.AddWithValue("@QuantityAvailable", inventory.QuantityAvailable);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw; // Re-throw the exception for handling at a higher level
            }
        }



    }
}
