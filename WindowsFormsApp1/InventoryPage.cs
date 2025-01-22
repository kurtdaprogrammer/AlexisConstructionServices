using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class InventoryPage : Form
    {

        public InventoryPage()
        {
            InitializeComponent();
            LoadServicesDropdown();
            ReadInventory();
            dataGridInventory.CellClick += InventoryGrid_CellClick;
            this.txtSearchInventory.TextChanged += new System.EventHandler(this.txtSearchInventory_TextChanged);

        }

        private void ReadInventory()
        {
            var repo = new InventoryRepository();
            var inventoryList = repo.GetInventories();

            // Initially display all items
            DisplayInventory(inventoryList);    

        }
        private void LoadServicesDropdown()
        {
            var servicesRepo = new Servicesrepository();
            var services = servicesRepo.GetServices(); // Get all services from the repository

            if (services == null || services.Count == 0)
            {
                MessageBox.Show(ALEXISMessages.NoServices, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            servicecb.DataSource = services;
            servicecb.DisplayMember = "ServiceName"; // Display the service name in the ComboBox
            servicecb.ValueMember = "ServiceID";    // Store the ServiceID in the value of ComboBox
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {

            try
            {
                // Validate the tool name
                if (string.IsNullOrWhiteSpace(Tooltb.Text))
                {
                    MessageBox.Show(ALEXISMessages.ToolNotempty, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate the service selection
                if (servicecb.SelectedValue == null || !int.TryParse(servicecb.SelectedValue.ToString(), out int serviceID))
                {
                    MessageBox.Show(ALEXISMessages.SelectValid, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate the quantity
                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show(ALEXISMessages.QuantityGreater, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create an Inventory object and populate its properties
                Inventory inventory = new Inventory
                {
                    ToolName = Tooltb.Text.Trim(), // Get the tool name from the textbox
                    ServiceID = serviceID, // Use validated service ID
                    QuantityAvailable = (int)numericUpDown1.Value // Get the quantity from numeric up-down control
                };

                // Use the repository to save the new inventory record
                var repo = new InventoryRepository();
                repo.CreateTool(inventory);

                // Refresh the DataGridView to show the updated inventory
                ReadInventory();
                MessageBox.Show(ALEXISMessages.ToolAdded, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the fields after adding the tool
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTool_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Delete button clicked.");

                if (dataGridInventory.SelectedRows.Count == 0)
                {
                    MessageBox.Show(ALEXISMessages.Selectarow, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var val = dataGridInventory.SelectedRows[0].Cells["ToolID"].Value?.ToString();
                if (string.IsNullOrEmpty(val))
                {
                    MessageBox.Show(ALEXISMessages.Selectarowinv, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int inventoryID = int.Parse(val);

                DialogResult dialogResult = MessageBox.Show(ALEXISMessages.DeleteConfirm, "Delete Inventory", MessageBoxButtons.YesNo);
                Console.WriteLine($"Dialog result: {dialogResult}");

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                var repo = new InventoryRepository();
                repo.DeleteInventory(inventoryID);

                // Refresh the grid and show success message
                ReadInventory();
                MessageBox.Show(ALEXISMessages.DeleteSuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid ToolID format: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InventoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row index is valid
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                var row = dataGridInventory.Rows[e.RowIndex];

                // Check if the required values are present in the row
                if (row.Cells["Tool Name"].Value != null)
                {
                    Tooltb.Text = row.Cells["Tool Name"].Value?.ToString();
                }

                if (row.Cells["Service Name"].Value != null)
                {
                    // Find the Service ID that corresponds to the selected service name
                    string serviceName = row.Cells["Service Name"].Value?.ToString();
                    var repo = new Servicesrepository();
                    var services = repo.GetServices(); // Get all services from the repository
                    var selectedService = services.FirstOrDefault(s => s.ServiceName == serviceName);

                    if (selectedService != null)
                    {
                        servicecb.SelectedValue = selectedService.ServiceID; // Set the ComboBox value
                    }
                }

                if (row.Cells["Quantity Available"].Value != null)
                {
                    numericUpDown1.Value = Convert.ToInt32(row.Cells["Quantity Available"].Value);
                }
            }
        }
        private void dataGridInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row index is valid
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                var row = dataGridInventory.Rows[e.RowIndex];

                // Check if the required values are present in the row
                if (row.Cells["Tool Name"].Value != null)
                {
                    Tooltb.Text = row.Cells["Tool Name"].Value?.ToString();
                }

                if (row.Cells["Service Name"].Value != null)
                {
                    servicecb.SelectedValue = row.Cells["Service Name"].Value?.ToString();
                }

                if (row.Cells["Quantity Available"].Value != null)
                {
                    numericUpDown1.Value = Convert.ToInt32(row.Cells["Quantity Available"].Value);
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the grid
            if (dataGridInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show(ALEXISMessages.Selectrowupdate, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridInventory.SelectedRows[0];

            // Get values from the selected row
            var toolIDValue = selectedRow.Cells["ToolID"].Value?.ToString();
            if (string.IsNullOrEmpty(toolIDValue))
            {
                MessageBox.Show(ALEXISMessages.InvalidToolID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int toolID = int.Parse(toolIDValue);

            // Get new values from the UI (e.g., textboxes, dropdowns)
            string newToolName = Tooltb.Text;
            int newServiceID = Convert.ToInt32(servicecb.SelectedValue);
            int newQuantity = (int)numericUpDown1.Value;

            // Validate the input
            if (string.IsNullOrEmpty(newToolName))
            {
                MessageBox.Show(ALEXISMessages.InvalidToolname, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create an updated inventory object
            Inventory updatedInventory = new Inventory
            {
                ToolID = toolID,
                ToolName = newToolName,
                ServiceID = newServiceID,
                QuantityAvailable = newQuantity
            };

            // Update the inventory record in the database
            var repo = new InventoryRepository();
            try
            {
                repo.UpdateTool(updatedInventory);
                ReadInventory(); // Refresh the grid
                MessageBox.Show(ALEXISMessages.ToolUpdateSuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the fields after update
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            Tooltb.Clear(); // Clear the Tool Name textbox
            servicecb.SelectedIndex = -1; // Reset the service dropdown
            numericUpDown1.Value = 0; // Reset the quantity numeric up-down
        }

      
        private void txtSearchInventory_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchInventory.Text.Trim().ToLower();

            // Filter the inventory list based on search text
            var repo = new InventoryRepository();
            var inventoryList = repo.GetInventories();

            // Filter the list using LINQ
            var filteredInventory = inventoryList
                .Where(item => item.ToolID.ToString().Contains(searchText) || item.ToolName.ToLower().Contains(searchText))
                .ToList();

            // Reload the grid with filtered data
            DisplayInventory(filteredInventory);
        }
        private void DisplayInventory(List<Inventory> inventoryList)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ToolID");
            dataTable.Columns.Add("Tool Name");
            dataTable.Columns.Add("Service Name");
            dataTable.Columns.Add("Quantity Available");

            foreach (var inventory in inventoryList)
            {
                var row = dataTable.NewRow();
                row["ToolID"] = inventory.ToolID;
                row["Tool Name"] = inventory.ToolName;
                row["Service Name"] = inventory.ServiceName; // Ensure ServiceName is correctly mapped
                row["Quantity Available"] = inventory.QuantityAvailable;

                dataTable.Rows.Add(row);
            }

            this.dataGridInventory.DataSource = dataTable;

            if (this.dataGridInventory.Columns["ToolID"] != null)
            {
                this.dataGridInventory.Columns["ToolID"].Visible = false;
            }
        }


    }
}
