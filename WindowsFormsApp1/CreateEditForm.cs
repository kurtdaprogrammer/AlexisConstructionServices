using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.Messages;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class CreateEditForm : Form
    {
        public CreateEditForm()
        {
            InitializeComponent();
            
            this.DialogResult = DialogResult.Cancel;
        }

        private int clientId = 0;
        public void EditClient(Client client)
        {
            
            MessageBox.Show($"Editing Client - ID: {client.ClientID}, Name: {client.Name}, Contact: {client.Contact}, Address: {client.Address}");

            this.Text = "Edit Client";
            this.lbTitle.Text = "Edit Client";

          
            this.lbclient.Text = client.ClientID.ToString();
            this.Nametb.Text = client.Name;
            this.Addresstb.Text = client.Address;
            this.Contacttb.Text = client.Contact;

            // Store the client ID for later use when saving
            this.clientId = client.ClientID;

        }

        private void clientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.alexisconstructionDBDataSet);

        }

        private void CreateEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'alexisconstructionDBDataSet.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.alexisconstructionDBDataSet.Clients);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.ClientID = this.clientId;
            client.Name = this.Nametb.Text;
            client.Contact = this.Contacttb.Text;
            client.Address = this.Addresstb.Text;

            if (string.IsNullOrEmpty(Nametb.Text) && string.IsNullOrEmpty(Contacttb.Text) && string.IsNullOrEmpty(Addresstb.Text))
            {
                MessageBox.Show(ALEXISMessages.Erroremptyfields);
                return;
            }

            var repo = new Clientrepository();
            if (client.ClientID==0)
            {
                repo.CreateClient(client);
            }
            else
            {
                repo.UpdateClient(client);
            }

            this.DialogResult= DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
