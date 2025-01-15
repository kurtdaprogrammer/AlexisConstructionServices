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
        }

        private void ReadInventory()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ToolID");
            dataTable.Columns.Add("Tool Name");
            dataTable.Columns.Add("Service Name");
            dataTable.Columns.Add("Quantity Available");

            var repo = new InventoryRepository();
            var inventoryList = repo.GetInventories();

            foreach (var inventory in inventoryList)
            {
                var row = dataTable.NewRow();

                row["ToolID"] = inventory.ToolID;
                row["Tool Name"] = inventory.ToolName;
                row["Service Name"] = inventory.ServiceName; // Use ServiceName instead of ServiceID
                row["Quantity Available"] = inventory.QuantityAvailable;

                dataTable.Rows.Add(row);
            }

            this.dataGridInventory.DataSource = dataTable;  

        }
        private void LoadServicesDropdown()
        {
            var servicesRepo = new Servicesrepository();
            var services = servicesRepo.GetServices(); // Get all services from the repository

            if (services == null || services.Count == 0)
            {
                MessageBox.Show("No services found in the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Tool name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate the service selection
                if (servicecb.SelectedValue == null || !int.TryParse(servicecb.SelectedValue.ToString(), out int serviceID))
                {
                    MessageBox.Show("Please select a valid service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate the quantity
                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Tool added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var val = dataGridInventory.SelectedRows[0].Cells["ToolID"].Value?.ToString();
                if (string.IsNullOrEmpty(val))
                {
                    MessageBox.Show("Selected row has an invalid ToolID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int inventoryID = int.Parse(val);

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Tool?", "Delete Inventory", MessageBoxButtons.YesNo);
                Console.WriteLine($"Dialog result: {dialogResult}");

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                var repo = new InventoryRepository();
                repo.DeleteInventory(inventoryID);

                // Refresh the grid and show success message
                ReadInventory();
                MessageBox.Show("Tool deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (e.RowIndex >= 0 && e.RowIndex < dataGridInventory.Rows.Count)
            {
                // Clear previous selection
                dataGridInventory.ClearSelection();
                dataGridInventory.Rows[e.RowIndex].Selected = true;

                var row = dataGridInventory.Rows[e.RowIndex];

                // Safely extract row values
                var toolIDValue = row.Cells["ToolID"].Value;
                var toolNameValue = row.Cells["Tool Name"].Value;
                var serviceNameValue = row.Cells["Service Name"].Value;
                var quantityValue = row.Cells["Quantity Available"].Value;

                // Log or use these values
                Console.WriteLine($"ToolID: {toolIDValue}, ToolName: {toolNameValue}, ServiceName: {serviceNameValue}, Quantity: {quantityValue}");
            }
            else
            {
                // If the click is invalid, skip processing
                Console.WriteLine("Invalid row clicked.");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridInventory.SelectedRows[0];

            // Get values from the selected row
            var toolIDValue = selectedRow.Cells["ToolID"].Value?.ToString();
            if (string.IsNullOrEmpty(toolIDValue))
            {
                MessageBox.Show("Invalid Tool ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Tool name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Tool updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                var row = dataGridInventory.Rows[e.RowIndex];

                // Populate controls with the selected row's data
                Tooltb.Text = row.Cells["Tool Name"].Value?.ToString();
                servicecb.SelectedValue = row.Cells["Service Name"].Value; // Ensure ServiceID is stored as the ValueMember
                numericUpDown1.Value = Convert.ToInt32(row.Cells["Quantity Available"].Value);
            }
        }

    }
}
