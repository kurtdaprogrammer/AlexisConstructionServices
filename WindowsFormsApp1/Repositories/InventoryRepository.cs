using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class InventoryRepository
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlexisconstructionDB;Integrated Security=True";

        public List<Inventory> GetInventory()
        {

            var inventoryList = new List<Inventory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Inventory ORDER BY ToolID DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Inventory inventory = new Inventory();
                                inventory.ToolID = reader.GetInt32(0);
                                inventory.ToolName = reader.GetString(1);
                                inventory.ServiceID = reader.GetInt32(2);
                                inventory.QuantityAvailable = reader.GetInt32(3);



                                inventoryList.Add(inventory);


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.Message);
            }

            return inventoryList;
        }
    }
}
