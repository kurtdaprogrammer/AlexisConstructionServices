using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class ClientPage : Form
    {
        public ClientPage()
        {
            InitializeComponent();
            ReadClients();  // Initial load of all clients
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
        }

        // Method to read and display clients with optional filtering
        private void ReadClients(string searchQuery = "")
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ClientID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Contact");
            dataTable.Columns.Add("Address");

            var repo = new Clientrepository();
            var clients = repo.GetClients();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Filter clients by ClientID or Name based on the search query
                clients = clients.Where(client => client.ClientID.ToString().Contains(searchQuery) ||
                                                  client.Name.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Add filtered clients to the DataTable
            foreach (var client in clients)
            {
                var row = dataTable.NewRow();
                row["ClientID"] = client.ClientID;
                row["Name"] = client.Name;
                row["Contact"] = client.Contact;
                row["Address"] = client.Address;
                dataTable.Rows.Add(row);
            }

            // Bind DataTable to DataGridView
            this.ClientsTable.DataSource = dataTable;

            // Optionally hide ClientID column
            if (this.ClientsTable.Columns["ClientID"] != null)
            {
                this.ClientsTable.Columns["ClientID"].Visible = false;
            }
        }

        // Event handler for when the text in the search TextBox changes
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the text entered in the search TextBox
            string searchQuery = txtSearch.Text.Trim();

            // Call ReadClients with the search query to filter the results
            ReadClients(searchQuery);
        }

        // Add Client button click event handler
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            CreateEditForm form = new CreateEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ReadClients();  // Refresh the client list after adding a new client
            }
        }

        // Edit Client button click event handler
        private void btnEditClient_Click(object sender, EventArgs e)
        {
            var val = this.ClientsTable.SelectedRows[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(val)) return;

            int clientId = int.Parse(val);

            var repo = new Clientrepository();
            var client = repo.GetClient(clientId);

            if (client == null) return;

            CreateEditForm form = new CreateEditForm();
            form.EditClient(client);

            // Show the form and handle the result
            if (form.ShowDialog() == DialogResult.OK)
            {
                ReadClients();  // Refresh the client list after editing
            }
        }

        // Delete Client button click event handler
        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            var val = this.ClientsTable.SelectedRows[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(val)) return;

            int clientId = int.Parse(val);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Client?", "Delete Client", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var repo = new Clientrepository();
            repo.DeleteClient(clientId);

            ReadClients();  // Refresh the client list after deletion
        }


    }
}