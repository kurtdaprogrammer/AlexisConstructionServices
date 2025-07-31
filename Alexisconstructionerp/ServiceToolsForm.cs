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
    public partial class ServiceToolsForm : Form
    {
        private readonly ServicesToolscontroller _servicestoolscontroller;

        public ServiceToolsForm()
        {
            InitializeComponent();
            LoadServicesToolsToGrid();
            LoadComboBoxes();
        }
        private void LoadServicesToolsToGrid()
        {
            ServicesToolscontroller repo = new ServicesToolscontroller();
            var servicestools = repo.GetServicesToolsView(); // returns names
            Servicestoolsgrid.DataSource = servicestools;
            if (Servicestoolsgrid.Columns["ServiceTool_ID"] != null)
                Servicestoolsgrid.Columns["ServiceTool_ID"].Visible = false;
            Servicestoolsgrid.ClearSelection();
            Servicestoolsgrid.CurrentCell = null;

        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadComboBoxes()
        {
            Servicescontroller serviceRepo = new Servicescontroller();
            Inventorycontroller inventoryRepo = new Inventorycontroller();

           
            cbService.DataSource = serviceRepo.GetServices();
            cbService.DisplayMember = "Service_Name";   
            cbService.ValueMember = "Service_ID";       

            cbTools.DataSource = inventoryRepo.GetInventories();
            cbTools.DisplayMember = "Tool_Name";        
            cbTools.ValueMember = "Inventory_ID";       
        }

        private void btnaddmapping_Click(object sender, EventArgs e)
        {
            int selectedServiceID = Convert.ToInt32(cbService.SelectedValue);
            int selectedToolID = Convert.ToInt32(cbTools.SelectedValue);
            int quantity = (int)numQty.Value;

            ServicesToolscontroller repo = new ServicesToolscontroller();
            repo.InsertMapping(selectedServiceID, selectedToolID, quantity);

            LoadServicesToolsToGrid();
        }

        private void deleteservicesbt_Click(object sender, EventArgs e)
        {
            DialogResult result = Helper.Helper.ValidateDelete();
            if (result == DialogResult.Yes)
            {
                if (Servicestoolsgrid.SelectedRows.Count > 0)
                {
                    int selectedId = Convert.ToInt32(Servicestoolsgrid.SelectedRows[0].Cells["ServiceTool_ID"].Value);

                    ServicesToolscontroller repo = new ServicesToolscontroller();
                    repo.RemoveServiceTools(selectedId);

                    MessageBox.Show("Service Mapping deleted successfully!");
                    LoadServicesToolsToGrid();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
                
        }
       
    }
}
