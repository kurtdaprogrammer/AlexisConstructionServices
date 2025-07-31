using create_edit_client.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace create_edit_client.Repositories
{
    public class Clientrepository
    {
        string conn = "Data Source=DESKTOP-3S4GF2N\\SQLEXPRESS;Initial Catalog=ALEXISCONSTRUCTIONENHANCED;Integrated Security=True;Encrypt=False";

        public List<Client> Getclients()
        {
            var clientList = new List<Client>();

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Clients ORDER BY Client_ID DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Client client = new Client();
                                client.Client_Id = reader.GetInt32(0);
                                client.Client_fname = reader.GetString(1);
                                client.Client_lname = reader.GetString(2);
                                client.Client_Address = reader.GetString(3);
                                client.Client_Phoneno = reader.GetString(4);
                                client.Client_Email = reader.GetString(5); // ✅ Correct index

                                clientList.Add(client); // ✅ Add to the list
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return clientList;
        }

        public void Createclient(Client client)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string sql = @"INSERT INTO Clients 
                            (Client_fname, Client_lname, Client_Address, Client_Phoneno, Client_Email)
                           VALUES 
                            (@fname, @lname, @address, @phoneno, @email)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@fname", client.Client_fname);
                        command.Parameters.AddWithValue("@lname", client.Client_lname);
                        command.Parameters.AddWithValue("@address", client.Client_Address);
                        command.Parameters.AddWithValue("@phoneno", client.Client_Phoneno);
                        command.Parameters.AddWithValue("@email", client.Client_Email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {

            }



        }

    }
}
