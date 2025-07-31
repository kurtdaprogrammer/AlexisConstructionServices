using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlexisErp.Repository;

namespace AlexisERP
{
    public partial class Add : Form
    {
        private readonly ClientRepository _clientRepository;
        public Add()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository();
            LoadClientsToGrid();
            clientviewer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientviewer.MultiSelect = false;
        }
        private void LoadClientsToGrid()
        {
            ClientRepository repo = new ClientRepository();
            var clients = repo.GetAllClients();
            clientviewer.DataSource = clients;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                Name = tbName.Text,
                Address = tbAddress.Text
            };

            _clientRepository.AddClient(client);

            LoadClientsToGrid();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (clientviewer.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(clientviewer.SelectedRows[0].Cells["Person_id"].Value);

                ClientRepository repo = new ClientRepository();
                repo.DeleteClient(selectedId);

                MessageBox.Show("Client deleted successfully!");
                LoadClientsToGrid(); // Refresh

            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}
