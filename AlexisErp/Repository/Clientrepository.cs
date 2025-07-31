using System;
using System.Collections.Generic;
using System.Configuration;
using AlexisERP.Alexismessages;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace AlexisErp.Repository
{
    public class Client : AlexisERP.Models.IClient
    {
        public int Person_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class ClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AddClient(AlexisERP.Models.IClient client)
        {
            if (string.IsNullOrWhiteSpace(client.Name) || string.IsNullOrWhiteSpace(client.Address))
            {
                MessageBox.Show(Alexismessages.error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Testtb (Person, Address) VALUES (@Person, @Address)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Person", client.Name);
                        command.Parameters.AddWithValue("@Address", client.Address);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Client saved successfully!");
            }
        }

        public List<AlexisERP.Models.IClient> GetAllClients()
        {
            var clients = new List<AlexisERP.Models.IClient>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Person_id, Person, Address FROM Testtb";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Person_id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2)
                        });
                    }
                }
            }

            return clients;
        }
        public void DeleteClient(int personId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Testtb WHERE Person_id = @PersonId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonId", personId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}