using Alexisconstructionerp.Controllers;
using System.Windows.Forms;

namespace Alexisconstructionerp
{
    public partial class Clientform : Form
    {
        private readonly Clientscontroller _clientscontroller;
        public Clientform()
        {
            InitializeComponent();
            _clientscontroller = new Clientscontroller();
            LoadClientsToGrid();
            ClientDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClientDataGrid.MultiSelect = false;
        }
        private void LoadClientsToGrid()
        {
            Clientscontroller repo = new Clientscontroller();
            var clients = repo.GetClients();
            ClientDataGrid.DataSource = clients;
            ClientDataGrid.ClearSelection();
        }
        private void Addclientbt_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients
            {
                Client_Name = Clientnametb.Text.Trim(),
                Client_Address = Clientaddresstb.Text.Trim(),
                Client_Phoneno = Clientphonenotb.Text.Trim(),
                Client_Email = Clientemailtb.Text.Trim()
            };
            _clientscontroller.AddClient(clients);
            LoadClientsToGrid();
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            DialogResult result = Helper.Helper.ValidateDelete();
            if (result == DialogResult.Yes) {
                if (ClientDataGrid.SelectedRows.Count > 0)
                {
                    int selectedId = Convert.ToInt32(ClientDataGrid.SelectedRows[0].Cells["Client_ID"].Value);

                    Clientscontroller repo = new Clientscontroller();
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

        private void EditClient_Click(object sender, EventArgs e)
        {
            if (ClientDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Get the selected row
            var row = ClientDataGrid.SelectedRows[0];

            // Extract data from the selected row
            var selectedClient = new Clients
            {
                Client_id = Convert.ToInt32(row.Cells["Client_id"].Value),
                Client_Name = row.Cells["Client_Name"].Value.ToString(),
                Client_Address = row.Cells["Client_Address"].Value.ToString(),
                Client_Phoneno = row.Cells["Client_Phoneno"].Value.ToString(),
                Client_Email = row.Cells["Client_Email"].Value.ToString()
            };

            // Open the UpdateClient form
            var updateForm = new UpdateClient(selectedClient);
            updateForm.ShowDialog();
            LoadClientsToGrid();
        }
    }
}
