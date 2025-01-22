using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Messages;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class Clientrepository
    {

        public List<Client> GetClients()
        {

            var clientList = new List<Client>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();

                    string sql = ALEXISMessages.SelectClients;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Client client = new Client();
                                client.ClientID = reader.GetInt32(0);
                                client.Name = reader.GetString(1);
                                client.Contact = reader.GetString(2);
                                client.Address = reader.GetString(3);

                                clientList.Add(client);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.Message);
            }

            return clientList;
        }

        public Client GetClient(int ClientID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.SelectGetClients;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", ClientID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Client client = new Client();
                                client.ClientID = reader.GetInt32(0);
                                client.Name = reader.GetString(1);
                                client.Contact = reader.GetString(2);
                                client.Address = reader.GetString(3);

                                return client;
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

        public void CreateClient(Client client)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.CreateClient;

                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", client.Name);
                        command.Parameters.AddWithValue("@Contact", client.Contact);
                        command.Parameters.AddWithValue("@Address", client.Address);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
        }

        public void UpdateClient(Client client)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();
                    string sql = ALEXISMessages.UpdateClient;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", client.Name);
                        command.Parameters.AddWithValue("@Contact", client.Contact);
                        command.Parameters.AddWithValue("@Address", client.Address);
                        command.Parameters.AddWithValue("@ClientID", client.ClientID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
        }

        public void DeleteClient(int ClientID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AlexisconstructionDBConnectionString))
                {
                    connection.Open();

                    string sql = ALEXISMessages.DeleteClient;
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("@ClientID", ClientID);

                        command.ExecuteNonQuery ();
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
