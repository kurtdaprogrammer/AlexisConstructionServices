using BOGSYDVDRENT.Helpers;
using BOGSYDVDRENT.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Controllers
{
    public class Customers : BOGSYDVDRENT.Models.ICustomers
    {
        public int CustomerID { get; set; }
        public required string Name { get; set; }
        public required string ContactNumber { get; set; }
        public required string Address { get; set; }
    }

    public class CustomersController
    {
        private readonly string _connectionString;

        public CustomersController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AddCustomer(ICustomers customers)
        {
            if (string.IsNullOrWhiteSpace(customers.Name) || string.IsNullOrWhiteSpace(customers.Address) || string.IsNullOrWhiteSpace(customers.ContactNumber))
            {
                MessageBox.Show("There are empty fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Customerstb (Name,ContactNumber,Address) VALUES (@Name,@ContactNumber,@Address)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", customers.Name);
                        command.Parameters.AddWithValue("@ContactNumber", customers.ContactNumber);
                        command.Parameters.AddWithValue("@Address", customers.Address);
                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Customer Added successfully!");
        }
        public List<ICustomers> GetCustomers()
        {
            var customers = new List<ICustomers>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CustomerID,Name, ContactNumber, Address FROM Customerstb";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customers
                        {
                            CustomerID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ContactNumber = reader.GetString(2),
                            Address = reader.GetString(3),
                        });
                    }
                }
            }
            return customers;
        }
        public void DeleteCustomer(int CustomerID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Customerstb WHERE CustomerID = @CustomerID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void EditCustomer(Customers customers)
        {
            if (string.IsNullOrEmpty(customers.Name) || string.IsNullOrEmpty(customers.Address) || string.IsNullOrEmpty(customers.ContactNumber))
            {
                MessageBox.Show("There are empty fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Customerstb 
                             SET Name = @Name, 
                                 ContactNumber = @ContactNumber,
                                 Address = @Address
                             WHERE CustomerID = @CustomerID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
                    command.Parameters.AddWithValue("@Name", customers.Name.Trim());
                    command.Parameters.AddWithValue("@ContactNumber", customers.ContactNumber.Trim());
                    command.Parameters.AddWithValue("@Address", customers.Address.Trim());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Customer record was updated. Please check the Customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        public Customers GetCustomerByID(int customerId)
        {
            Customers customer = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT CustomerID, Name, ContactNumber, Address FROM Customerstb WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customers
                            {
                                CustomerID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                ContactNumber = reader.GetString(2),
                                Address = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return customer;
        }
        
    }
}

