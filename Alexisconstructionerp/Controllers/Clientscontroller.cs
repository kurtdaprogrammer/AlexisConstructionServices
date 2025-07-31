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
    public class Clients : Alexisconstructionerp.Models.IClients
    {
        public int Client_id { get; set; }
        public string Client_Name { get; set; }
        public string Client_Address { get; set; }
        public string Client_Phoneno { get; set; }
        public string Client_Email { get; set; }
    }
    public class Clientscontroller 
    {
        private readonly string _connectionString;
        public Clientscontroller()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AddClient(Alexisconstructionerp.Models.IClients client) {
            if (string.IsNullOrWhiteSpace(client.Client_Name) || string.IsNullOrWhiteSpace(client.Client_Address) || string.IsNullOrWhiteSpace(client.Client_Phoneno) || string.IsNullOrWhiteSpace(client.Client_Email))
            {
                MessageBox.Show("There are empty fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Clientstb (Client_Name,Client_Address,Client_Phoneno,Client_Email) VALUES (@Client_Name,@Client_Address,@Client_Phoneno,@Client_Email)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Client_Name", client.Client_Name);
                        command.Parameters.AddWithValue("@Client_Address", client.Client_Address);
                        command.Parameters.AddWithValue("@Client_Phoneno", client.Client_Phoneno);
                        command.Parameters.AddWithValue("@Client_Email", client.Client_Email);
                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Client saved successfully!");
        }

        public List<Alexisconstructionerp.Models.IClients> GetClients() {
            var clients = new List<Alexisconstructionerp.Models.IClients>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Client_ID,Client_Name, Client_Address, Client_Phoneno, Client_Email FROM Clientstb";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Clients
                        {
                            Client_id = reader.GetInt32(0),
                            Client_Name = reader.GetString(1),
                            Client_Address = reader.GetString(2),
                            Client_Phoneno = reader.GetString(3),
                            Client_Email = reader.GetString(4)                   
                        });
                    }
                }
            }
            return clients;
        }

        public void DeleteClient(int client_id) {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM CLientstb WHERE Client_ID = @Client_ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Client_ID", client_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditClient(Clients client) {
            if (string.IsNullOrWhiteSpace(client.Client_Name) ||
                string.IsNullOrWhiteSpace(client.Client_Address) ||
                string.IsNullOrWhiteSpace(client.Client_Phoneno) ||
                string.IsNullOrWhiteSpace(client.Client_Email))
            {
                MessageBox.Show("There are empty fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Clientstb 
                             SET Client_Name = @Client_Name, 
                                 Client_Address = @Client_Address, 
                                 Client_Phoneno = @Client_Phoneno, 
                                 Client_Email = @Client_Email 
                             WHERE Client_ID = @Client_ID";
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@Client_ID", client.Client_id);
                    command.Parameters.AddWithValue("@Client_Name", client.Client_Name.Trim());
                    command.Parameters.AddWithValue("@Client_Address", client.Client_Address.Trim());
                    command.Parameters.AddWithValue("@Client_Phoneno", client.Client_Phoneno.Trim());
                    command.Parameters.AddWithValue("@Client_Email", client.Client_Email.Trim());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No client record was updated. Please check the Client ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
              
            }
        }
    }
}
