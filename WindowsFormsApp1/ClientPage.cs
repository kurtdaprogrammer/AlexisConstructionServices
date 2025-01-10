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

            ReadClients();
        }

        private void ReadClients()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ClientID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Contact");
            dataTable.Columns.Add("Address");

            var repo = new Clientrepository();
            var clients = repo.GetClients();

            foreach (var client in clients)
            {
                var row = dataTable.NewRow();

                row["ClientID"] = client.ClientID;
                row["Name"] = client.Name;
                row["Contact"] = client.Contact;
                row["Address"] = client.Address;

                dataTable.Rows.Add(row);
            }

            this.ClientsTable.DataSource = dataTable;

        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            CreateEditForm form = new CreateEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
             
                ReadClients();
            }
        }

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
                
                ReadClients();
            }
        }

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

            ReadClients();
        }

       
    }
}