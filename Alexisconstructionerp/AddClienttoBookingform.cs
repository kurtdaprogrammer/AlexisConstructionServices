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

    public partial class AddClienttoBookingform : Form
    {
        private readonly Clientscontroller _clientscontroller;
        public int SelectedClientId { get; private set; }
        public string SelectedClientName { get; private set; }
      
        public AddClienttoBookingform()
        {
            InitializeComponent();
            _clientscontroller = new Clientscontroller();
            LoadClientsToGrid();
            ClientsViewdg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClientsViewdg.MultiSelect = false;
            ClientsViewdg.CellClick += ClientsViewdg_CellClick;
            

        }
        private void LoadClientsToGrid()
        {
            Clientscontroller repo = new Clientscontroller();
            var clients = repo.GetClients();
            ClientsViewdg.DataSource = clients;
            ClientsViewdg.ClearSelection();
        }
        private void ClientsViewdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedClientId = Convert.ToInt32(ClientsViewdg.Rows[e.RowIndex].Cells["Client_ID"].Value);
                SelectedClientName = ClientsViewdg.Rows[e.RowIndex].Cells["Client_Name"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
