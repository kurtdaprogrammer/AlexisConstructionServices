using Alexisconstructionerp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexisconstructionerp
{
    public partial class UpdateClient : Form
    {
        private readonly int clientId;

        public UpdateClient(Clients selectedClient)
        {
            InitializeComponent();
            // Store Client ID for updating later
            clientId = selectedClient.Client_id;

            // Populate the textboxes
            Clientnametb.Text = selectedClient.Client_Name;
            Clientaddresstb.Text = selectedClient.Client_Address;
            Clientphonenotb.Text = selectedClient.Client_Phoneno;
            Clientemailtb.Text = selectedClient.Client_Email;
        }   

        private void UpdateClienttb_Click(object sender, EventArgs e)
        {
            var controller = new Clientscontroller();
            var updatedClient = new Clients
            {
                Client_id = this.clientId, // must be set from constructor
                Client_Name = Clientnametb.Text,
                Client_Address = Clientaddresstb.Text,
                Client_Phoneno = Clientphonenotb.Text,
                Client_Email = Clientemailtb.Text
            };

            controller.EditClient(updatedClient);
            this.Close();
        }
    }
}
