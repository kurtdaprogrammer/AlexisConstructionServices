﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class BillingPage : Form
    {
        private BillingRepository billingRepo = new BillingRepository();
        private Bookingsrepository bookingsRepo = new Bookingsrepository();
        public BillingPage()
        {
            InitializeComponent();
   
            LoadBillingData();
            ClearFields();
            Searchbox.TextChanged += Searchbox_TextChanged;

        }
        // Load Billing data into DataGridView
        private void LoadBillingData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("BillingID");
            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("BillingReference");  // Ensure this column is added
            dataTable.Columns.Add("ClientName"); // Add ClientName column after BillingReference
            dataTable.Columns.Add("AmountDue");
            dataTable.Columns.Add("AmountPaid");
            dataTable.Columns.Add("PaymentStatus");

            var repo = new BillingRepository();
            var billings = repo.GetBillings(); // Get Billings from repository

            foreach (var billing in billings)
            {
                var row = dataTable.NewRow();

                row["BillingID"] = billing.BillingID;
                row["BookingID"] = billing.BookingID;
                row["BillingReference"] = billing.BillingReference; // Map BillingReference here
                row["ClientName"] = billing.ClientName; // Map ClientName here
                row["AmountDue"] = billing.AmountDue;
                row["AmountPaid"] = billing.AmountPaid;
                row["PaymentStatus"] = billing.PaymentStatus;

                dataTable.Rows.Add(row);
            }

            // Assign the populated DataTable to the DataGrid
            this.dataGridBilling.DataSource = dataTable;

            // Optional: Hide columns that are not needed
            this.dataGridBilling.Columns["BillingID"].Visible = false;
            this.dataGridBilling.Columns["BookingID"].Visible = false;

            // Clear the selection after binding the data
            dataGridBilling.ClearSelection();


        }
     

     
        

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if BookingID is selected from the SelectedRef TextBox
                if (string.IsNullOrEmpty(SelectedRef.Text))
                {
                    MessageBox.Show("Please select a booking reference.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if Amount Paid is entered, if not, set it to 0
                decimal amountPaid = string.IsNullOrEmpty(amtpaidtb.Text) ? 0 : decimal.Parse(amtpaidtb.Text);

                // Check if Amount Paid is greater than or equal to Amount Due
                decimal amountDue = decimal.Parse(amttb.Text);
                string paymentStatus = amountPaid >= amountDue ? "Paid" : "Pending";

                // Generate a unique BillingReference
                string billingReference = "BILL-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Create a new Billing object
                Billing billing = new Billing
                {
                    BookingID = Convert.ToInt32(SelectedRef.Tag), // Use the BookingID stored in the Tag property of SelectedRef
                    AmountDue = amountDue,
                    AmountPaid = amountPaid,
                    PaymentStatus = paymentStatus,
                    BillingReference = billingReference
                };

                // Call the repository to create the billing record
                billingRepo.CreateBilling(billing);  // This calls the CreateBilling method

                // Show success message
                MessageBox.Show("Billing record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the billing data in the grid
                LoadBillingData();

                // Clear fields after adding
                ClearFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Amount Due and Amount Paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding billing record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            // Ensure there are rows in the DataGridView
            if (dataGridBilling.Rows.Count == 0)
            {
                MessageBox.Show("No billing records available to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if a row is selected
            if (dataGridBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a billing record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridBilling.SelectedRows[0];

            // Ensure the selected row is valid
            if (selectedRow.Cells["BillingID"].Value == null || selectedRow.Cells["BookingID"].Value == null)
            {
                MessageBox.Show("Invalid selection. Please select a valid billing record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int billingID = Convert.ToInt32(selectedRow.Cells["BillingID"].Value);
                int bookingID = Convert.ToInt32(selectedRow.Cells["BookingID"].Value);
                string billingReference = selectedRow.Cells["BillingReference"].Value?.ToString() ?? "N/A";
                decimal amountDue = Convert.ToDecimal(selectedRow.Cells["AmountDue"].Value);
                decimal amountPaid = Convert.ToDecimal(selectedRow.Cells["AmountPaid"].Value);
                string paymentStatus = selectedRow.Cells["PaymentStatus"].Value?.ToString() ?? "Unknown";

                // Fetch client name using the BookingID
                var booking = bookingsRepo.GetBooking(bookingID);
                string clientName = booking?.ClientName ?? "Unknown"; // Fallback if client name is not found

                // Open the update form and pass the necessary data
                var updateForm = new BillingUpdateForm(billingID, bookingID, billingReference, amountDue, amountPaid, paymentStatus, clientName);
                updateForm.ShowDialog();

                // Reload data after update
                LoadBillingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while attempting to update the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Populate fields when a DataGrid row is clicked
        private void dataGridBilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row index is valid
            if (e.RowIndex >= 0 && e.RowIndex < dataGridBilling.Rows.Count)
            {
                // Clear previous selection
                dataGridBilling.ClearSelection();
                dataGridBilling.Rows[e.RowIndex].Selected = true;

                var row = dataGridBilling.Rows[e.RowIndex];

                // Extract necessary values from the selected row
                var billingID = Convert.ToInt32(row.Cells["BillingID"].Value);
                var bookingID = Convert.ToInt32(row.Cells["BookingID"].Value);
                var billingReference = row.Cells["BillingReference"].Value.ToString();
                var amountDue = Convert.ToDecimal(row.Cells["AmountDue"].Value);
                var amountPaid = Convert.ToDecimal(row.Cells["AmountPaid"].Value);
                var paymentStatus = row.Cells["PaymentStatus"].Value.ToString();

                // Fetch client name using the BookingID
                var booking = bookingsRepo.GetBooking(bookingID);
                string clientName = booking?.ClientName ?? "Unknown";  // Fallback if client name is not found

                // Populate textboxes on BillingPage form
                ClientNametb.Text = clientName;
                amttb.Text = amountDue.ToString();
                amtpaidtb.Text = amountPaid.ToString();

                // Open the update form and pass the necessary data (optional)
                BillingUpdateForm updateForm = new BillingUpdateForm(billingID, bookingID, billingReference, amountDue, amountPaid, paymentStatus, clientName);
                updateForm.ShowDialog();  // Show the form as a modal dialog
            }
        }
     
        private void ClearFields()
        {
            
            amttb.Clear(); // Clear Amount Due textbox
            amtpaidtb.Clear(); // Clear Amount Paid textbox
           
            ClientNametb.Clear(); // Clear Client Name textbox
        }

        private void btnDeleteTool_Click_1(object sender, EventArgs e)
        {
            if (dataGridBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridBilling.SelectedRows[0];
            int billingID = Convert.ToInt32(selectedRow.Cells["BillingID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this billing record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                billingRepo.DeleteBilling(billingID);
                MessageBox.Show("Billing record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBillingData();
            }
        }
        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            // Get the search term from the Searchbox
            string searchTerm = Searchbox.Text.Trim();

            // Reload the data with the search term passed to filter the data
            LoadBillingData(searchTerm);
        }
        private void LoadBillingData(string searchTerm = "")
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("BillingID");
            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("BillingReference");
            dataTable.Columns.Add("ClientName");
            dataTable.Columns.Add("AmountDue");
            dataTable.Columns.Add("AmountPaid");
            dataTable.Columns.Add("PaymentStatus");

            var repo = new BillingRepository();
            var billings = repo.GetBillings(); // Get Billings from repository

            foreach (var billing in billings)
            {
                // Apply search filter to the BillingReference and ClientName
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    string lowerSearchTerm = searchTerm.ToLower(); // Convert search term to lower case for case-insensitive comparison

                    if (!billing.BillingReference.ToLower().Contains(lowerSearchTerm) &&
                        !billing.ClientName.ToLower().Contains(lowerSearchTerm))
                    {
                        continue; // Skip this billing record if neither BillingReference nor ClientName matches the search term
                    }
                }

                var row = dataTable.NewRow();

                row["BillingID"] = billing.BillingID;
                row["BookingID"] = billing.BookingID;
                row["BillingReference"] = billing.BillingReference;
                row["ClientName"] = billing.ClientName;
                row["AmountDue"] = billing.AmountDue;
                row["AmountPaid"] = billing.AmountPaid;
                row["PaymentStatus"] = billing.PaymentStatus;

                dataTable.Rows.Add(row);
            }

            // Assign the populated DataTable to the DataGrid
            this.dataGridBilling.DataSource = dataTable;

            // Optional: Hide columns that are not needed
            this.dataGridBilling.Columns["BillingID"].Visible = false;
            this.dataGridBilling.Columns["BookingID"].Visible = false;

            // Clear the selection after binding the data
            dataGridBilling.ClearSelection();
        }

        private void SelectBooking_Click(object sender, EventArgs e)
        {
            using (SelectBookingRefForm selectBookingRefForm = new SelectBookingRefForm())
            {
                // Show the dialog and check if the user clicked OK
                if (selectBookingRefForm.ShowDialog() == DialogResult.OK)
                {
                    // Populate the fields with the selected booking information
                    SelectedRef.Text = selectBookingRefForm.SelectedBookingReference; // BookingReference
                    SelectedRef.Tag = selectBookingRefForm.SelectedBookingID;         // Store BookingID in the Tag property

                    // Optionally, populate other fields based on the selected booking
                    // Example: Assuming you have these fields to update in BillingPage
                    ClientNametb.Text = selectBookingRefForm.ClientName;   // Populate client name
                    amttb.Text = selectBookingRefForm.TotalAmount.ToString(); // Populate amount due
                }
            }
        }
    }
}
