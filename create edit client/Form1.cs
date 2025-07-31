using create_edit_client.Models;
using create_edit_client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace create_edit_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Readclient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aLEXISCONSTRUCTIONENHANCEDDataSet.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.aLEXISCONSTRUCTIONENHANCEDDataSet.Clients);

        }

        private void add_Click(object sender, EventArgs e)
        {
            Client newClient = new Client()
            {
                Client_fname = this.fname.Text,
                Client_lname = this.lname.Text,
                Client_Address = this.address.Text,
                Client_Phoneno = this.phone.Text,
                Client_Email = this.email.Text
            };

            var repo = new Clientrepository();
            repo.Createclient(newClient);

            MessageBox.Show("Client added successfully!");
            Readclient();

            Readclient();
        }

        private void Readclient()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Client_ID");
            dataTable.Columns.Add("Client_fname");
            dataTable.Columns.Add("Client_lname");
            dataTable.Columns.Add("Client_Address");
            dataTable.Columns.Add("Client_Phoneno");
            dataTable.Columns.Add("Client_Email");

            var repo = new Clientrepository();
            var clients = repo.Getclients();

            foreach (var client in clients)
            {
                var row = dataTable.NewRow();
                row["Client_ID"] = client.Client_Id;
                row["Client_fname"] = client.Client_fname;
                row["Client_lname"] = client.Client_lname;
                row["Client_Address"] = client.Client_Address;
                row["Client_Phoneno"] = client.Client_Phoneno;
                row["Client_Email"] = client.Client_Email;
                dataTable.Rows.Add(row);
            }

            this.dgvc.DataSource = dataTable;
        }
    }
}
