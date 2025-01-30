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
    public partial class SelectClientForm : Form
    {
        // Properties to store selected client details
        public int SelectedClientID { get; private set; }
        public string SelectedClientName { get; private set; }

        public SelectClientForm()
        {
            InitializeComponent();
            ReadClients();  // Initial load of all clients

            // Attach the TextChanged event to the Searchbox
            this.Searchbox.TextChanged += new EventHandler(this.Searchbox_TextChanged);
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
            var clients = repo.GetClients(); // Get all clients

            // If a search query is provided, filter the clients
            if (!string.IsNullOrEmpty(searchQuery))
            {
                clients = clients.Where(client =>
                    client.ClientID.ToString().Contains(searchQuery) ||
                    client.Name.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();
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
            this.clientview.DataSource = dataTable;

            // Optionally hide the ClientID column
            if (this.clientview.Columns["ClientID"] != null)
            {
                this.clientview.Columns["ClientID"].Visible = false;
            }
        }

        // Event handler for when the user types in the Searchbox
        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            // Get the text entered in the Searchbox
            string searchQuery = Searchbox.Text.Trim();

            // Call ReadClients with the search query to filter the results
            ReadClients(searchQuery);
        }

        // Event handler for when a client is selected in the DataGridView
        private void clientview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < clientview.Rows.Count)
            {
                clientview.Rows[e.RowIndex].Selected = true; // Ensure row selection

                SelectedClientID = Convert.ToInt32(clientview.Rows[e.RowIndex].Cells["ClientID"].Value);
                SelectedClientName = clientview.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            }
        }

        // Event handler for the Select Client button
        private void ClientSel_Click(object sender, EventArgs e)
        {
            if (clientview.SelectedRows.Count > 0)
            {
                var selectedRow = clientview.SelectedRows[0];

                SelectedClientID = Convert.ToInt32(selectedRow.Cells["ClientID"].Value);
                SelectedClientName = selectedRow.Cells["Name"].Value.ToString();

                this.DialogResult = DialogResult.OK; // Return selected client details
                this.Close(); // Close the form
            }
            else
            {
                MessageBox.Show("Please select a client.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Event handler for the Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
