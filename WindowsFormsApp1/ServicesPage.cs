using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Messages;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class ServicesPage : Form
    {
        public ServicesPage()
        {
            InitializeComponent();
            ServicesTable.CellClick += ServicesTable_CellClick;
            ReadServices();
        }

        private int serviceID = 0;
        private void ReadServices()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ServiceID");
            dataTable.Columns.Add("ServiceName");
            dataTable.Columns.Add("HourlyRate");

            var repo = new Servicesrepository();
            var services = repo.GetServices();

            foreach (var service in services)
            {
                var row = dataTable.NewRow();

                row["ServiceID"] = service.ServiceID;
                row["ServiceName"] = service.ServiceName;
                row["HourlyRate"] = service.HourlyRate;
              

                dataTable.Rows.Add(row);
            }

            this.ServicesTable.DataSource = dataTable;

            if (this.ServicesTable.Columns["ServiceID"] != null)
            {
                this.ServicesTable.Columns["ServiceID"].Visible = false;
            }

        }

        private void servicesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.servicesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.alexisconstructionDBDataSet);

        }

        private void ServicesPage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'alexisconstructionDBDataSet.Services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.alexisconstructionDBDataSet.Services);

        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            // Validate input fields before proceeding
            if (string.IsNullOrEmpty(Servicetb.Text) || string.IsNullOrEmpty(HourlyRatetb.Text))
            {
                MessageBox.Show(ALEXISMessages.ErrorEmpty, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(HourlyRatetb.Text, out decimal hourlyRate))
            {
                MessageBox.Show(ALEXISMessages.InvalidRate, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new service object
            Service service = new Service
            {
                ServiceID = this.serviceID, // Will be 0 for new services
                ServiceName = this.Servicetb.Text,
                HourlyRate = hourlyRate
            };

            var repo = new Servicesrepository();
            if (service.ServiceID == 0) // New service
            {
                repo.CreateService(service);
                ReadServices();
            }

            // Close the dialog with success result
            this.DialogResult = DialogResult.OK;
        }

       
        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (this.ServicesTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(ALEXISMessages.Selectedit, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var val = this.ServicesTable.SelectedRows[0].Cells["ServiceID"].Value?.ToString();

            if (string.IsNullOrEmpty(val))
            {
                MessageBox.Show(ALEXISMessages.Servicemissing, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(val, out int serviceID))
            {
                MessageBox.Show(ALEXISMessages.InvalidFormat, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repo = new Servicesrepository();
            var service = repo.GetService(serviceID);

            if (service == null)
            {
                MessageBox.Show(ALEXISMessages.Servicenotfound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            service.ServiceName = Servicetb.Text;
            if (!decimal.TryParse(HourlyRatetb.Text, out decimal hourlyRate))
            {
                MessageBox.Show(ALEXISMessages.InvalidHourlyRate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            service.HourlyRate = hourlyRate;

            if (string.IsNullOrEmpty(Servicetb.Text))
            {
                MessageBox.Show(ALEXISMessages.ServiceNameEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            repo.UpdateService(service);

            ReadServices();

            MessageBox.Show(ALEXISMessages.UpdateSuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ServicesTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                ServicesTable.ClearSelection(); // Clear any previous selections
                ServicesTable.Rows[e.RowIndex].Selected = true; // Select the clicked row

                var row = ServicesTable.Rows[e.RowIndex];

             
                Servicetb.Text = row.Cells["ServiceName"].Value.ToString();
                HourlyRatetb.Text = row.Cells["HourlyRate"].Value.ToString();
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {

            if (this.ServicesTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(ALEXISMessages.SelectRow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var val = this.ServicesTable.SelectedRows[0].Cells["ServiceID"].Value?.ToString();

            if (string.IsNullOrEmpty(val))
            {
                MessageBox.Show(ALEXISMessages.Servicemissing, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(val, out int serviceID))
            {
                MessageBox.Show(ALEXISMessages.InvalidFormat, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(ALEXISMessages.Deleteconf, "Delete Service", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var repo = new Servicesrepository();
            repo.DeleteService(serviceID);

            ReadServices();
        }
    }
}
