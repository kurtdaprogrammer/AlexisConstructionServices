using Alexisconstructionerp.Controllers;
using Microsoft.Data.SqlClient;
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
    public partial class Servicesform : Form
    {
        private readonly Servicescontroller _servicescontroller;
        public Servicesform()
        {
            InitializeComponent();
            LoadServicesToGrid();
            _servicescontroller = new Servicescontroller();
            this.Shown += Services_Shown;
            ServicesDataGrid.CellClick += ServicesDataGrid_CellClick;

        }
        private void LoadServicesToGrid()
        {
            Servicescontroller repo = new Servicescontroller();
            var services = repo.GetServices();
            ServicesDataGrid.DataSource = services;
            if (ServicesDataGrid.Columns["Service_ID"] != null)
            {
                ServicesDataGrid.Columns["Service_ID"].Visible = false;
            }
            ServicesDataGrid.ClearSelection();
            ServicesDataGrid.CurrentCell = null;

        }
        private void Addservicesbt_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Serviceshourlyratetb.Text.Trim(), out decimal qty))
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Services services = new Services
            {
                Service_Name = Servicesnametb.Text.Trim(),
                Hourly_Rate = qty
            };
            _servicescontroller.AddServices(services);
            LoadServicesToGrid();
        }
        private void ServicesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ServicesDataGrid.Rows[e.RowIndex];

                Servicesnametb.Text = row.Cells["Service_Name"].Value?.ToString().Trim();
                Serviceshourlyratetb.Text = row.Cells["Hourly_Rate"].Value?.ToString().Trim();
            }
        }
        private void ServicesDataGrid_SelectionChanged_1(object sender, EventArgs e)
        {
            if (ServicesDataGrid.SelectedRows.Count > 0)
            {
                var row = ServicesDataGrid.SelectedRows[0];
                Servicesnametb.Text = row.Cells["Service_Name"].Value?.ToString().Trim();
                Serviceshourlyratetb.Text = row.Cells["Hourly_Rate"].Value?.ToString().Trim();
            }
        }
        private void Services_Shown(object sender, EventArgs e)
        {
            ServicesDataGrid.ClearSelection();
            Servicesnametb.Clear();
            Serviceshourlyratetb.Clear();
        }
        private void Removeservicesbt_Click(object sender, EventArgs e)
        {
            DialogResult result = Helper.Helper.ValidateDelete();
            if (result == DialogResult.Yes)
            {
                if (ServicesDataGrid.SelectedRows.Count > 0)
                {
                    int selectedId = Convert.ToInt32(ServicesDataGrid.SelectedRows[0].Cells["Service_ID"].Value);

                    Servicescontroller repo = new Servicescontroller();
                    repo.RemoveService(selectedId);

                    MessageBox.Show("Service deleted successfully!");
                    LoadServicesToGrid();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
        }
        private void Editservicesbt_Click(object sender, EventArgs e)
        {
            if (ServicesDataGrid.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(Servicesnametb.Text) || string.IsNullOrWhiteSpace(Serviceshourlyratetb.Text))
            {
                MessageBox.Show("Please select a Service to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var row = ServicesDataGrid.SelectedRows[0];

                Services services = new Services
                {
                    Service_ID = Convert.ToInt32(row.Cells["Service_ID"].Value),
                    Service_Name = Servicesnametb.Text.Trim(),
                    Hourly_Rate = Convert.ToDecimal(Serviceshourlyratetb.Text.Trim())
                };
                Servicescontroller controller = new Servicescontroller();
                controller.EditServices(services);
            }
            LoadServicesToGrid();
        }
    }
}
