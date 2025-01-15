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
    public class InventoryRepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlexisconstructionDB;Integrated Security=True";

        public List<Inventory> GetInventories()
        {

            var inventoryList = new List<Inventory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                SELECT i.ToolID, i.ToolName, s.ServiceName, i.QuantityAvailable
                FROM Inventory i
                INNER JOIN Services s ON i.ServiceID = s.ServiceID
                ORDER BY i.ToolID DESC";

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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Inventory WHERE InventoryID=@InventoryID";
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Inventory" +
                        "(ToolName, ServiceID, QuantityAvailable) VALUES " +
                        "(@ToolName, @ServiceID, @QuantityAvailable);";

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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Inventory WHERE ToolID = @ToolID";

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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE Inventory " +
                                 "SET ToolName = @ToolName, ServiceID = @ServiceID, QuantityAvailable = @QuantityAvailable " +
                                 "WHERE ToolID = @ToolID";

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
