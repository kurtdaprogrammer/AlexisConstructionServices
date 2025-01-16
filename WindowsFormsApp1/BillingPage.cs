using System;
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
        public BillingPage()
        {
            InitializeComponent();
            dataGridBilling.CellClick += dataGridBilling_CellClick;  // Add this line
            LoadBookingsDropdown();
            LoadBillingData();
        }
        // Load Billing data into DataGridView
        private void LoadBillingData()
        {
            var billingData = billingRepo.GetBillings();
            var dataTable = new DataTable();

            dataTable.Columns.Add("BillingID");
            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("Amount Due");
            dataTable.Columns.Add("Amount Paid");
            dataTable.Columns.Add("Payment Status");

            foreach (var billing in billingData)
            {
                var row = dataTable.NewRow();
                row["BillingID"] = billing.BillingID;
                row["BookingID"] = billing.BookingID;
                row["Amount Due"] = billing.AmountDue;
                row["Amount Paid"] = billing.AmountPaid;
                row["Payment Status"] = billing.PaymentStatus;
                dataTable.Rows.Add(row);
            }

            dataGridBilling.DataSource = dataTable;

            // Set SelectionMode to FullRowSelect
            dataGridBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Optionally, you can also set ReadOnly if you want
            dataGridBilling.ReadOnly = true;
        }
        // Load Booking IDs into ComboBox
        private void LoadBookingsDropdown()
        {
            // Assuming you have a Bookingsrepository that fetches bookings from your database or another source
            var bookingsRepo = new Bookingsrepository();
            var bookings = bookingsRepo.GetBookings(); // Get all bookings from the repository

            // Bind the ComboBox to the list of bookings
            cbBookingID.DataSource = bookings;
            cbBookingID.DisplayMember = "BookingID";  // Display BookingID in the dropdown
            cbBookingID.ValueMember = "BookingID";    // Use BookingID as the ValueMember to bind

            // Optionally, you can set an event listener here if needed
            cbBookingID.SelectedIndexChanged += cbBookingID_SelectedIndexChanged;
        }
        // Event Handler to Display Amount Due for Selected Booking
        private void cbBookingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBookingID.SelectedValue == null)
                return;

            int selectedBookingID = Convert.ToInt32(cbBookingID.SelectedValue);
            var bookingsRepo = new Bookingsrepository();
            var booking = bookingsRepo.GetBooking(selectedBookingID);

            if (booking != null)
            {
                amttb.Text = booking.TotalAmount.ToString("0.00"); // Display the TotalAmount as Amount Due
            }
            else
            {
                amttb.Text = "0.00"; // Default if no booking is found
            }
        }
        

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if BookingID is selected
                if (cbBookingID.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a booking from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Stop execution if no BookingID is selected
                }

                // Check if Amount Paid is entered, if not, set it to 0
                decimal amountPaid = string.IsNullOrEmpty(amtpaidtb.Text) ? 0 : decimal.Parse(amtpaidtb.Text);

                // Check if Amount Paid is greater than or equal to Amount Due
                decimal amountDue = decimal.Parse(amttb.Text);
                string paymentStatus = amountPaid >= amountDue ? "Paid" : "Pending";

                // Set the label to show the payment status
                paymentlabel.Text = paymentStatus;

                // Create a new Billing object
                Billing billing = new Billing
                {
                    BookingID = Convert.ToInt32(cbBookingID.SelectedValue),
                    AmountDue = amountDue,
                    AmountPaid = amountPaid,
                    PaymentStatus = paymentStatus // Automatically set the Payment Status
                };

                // Call the repository to create the billing record
                billingRepo.CreateBilling(billing);

                // Show success message
                MessageBox.Show("Billing record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the billing data in the grid
                LoadBillingData();
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
            if (dataGridBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row from the DataGrid
            var selectedRow = dataGridBilling.SelectedRows[0];
            int billingID = Convert.ToInt32(selectedRow.Cells["BillingID"].Value);

            try
            {
                // Check if BookingID is selected
                if (cbBookingID.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a booking from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Stop execution if no BookingID is selected
                }

                // Check if Amount Paid is entered, if not, set it to 0
                decimal amountPaid = string.IsNullOrEmpty(amtpaidtb.Text) ? 0 : decimal.Parse(amtpaidtb.Text);

                // Check if Amount Due is provided, it should not be empty
                decimal amountDue = decimal.Parse(amttb.Text);
                if (amountDue <= 0)
                {
                    MessageBox.Show("Amount Due should be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop execution if Amount Due is invalid
                }

                // Check if Amount Paid is greater than or equal to Amount Due
                string paymentStatus = amountPaid >= amountDue ? "Paid" : "Pending";

                // Set the label to show the payment status
                paymentlabel.Text = paymentStatus;

                // Create a new Billing object with the updated data
                Billing billing = new Billing
                {
                    BillingID = billingID,
                    BookingID = Convert.ToInt32(cbBookingID.SelectedValue),
                    AmountDue = amountDue,
                    AmountPaid = amountPaid,
                    PaymentStatus = paymentStatus // Automatically set the Payment Status
                };

                // Call the repository to update the billing record
                billingRepo.UpdateBilling(billing);

                // Show success message
                MessageBox.Show("Billing record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the billing data in the grid
                LoadBillingData();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Amount Due and Amount Paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating billing record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Populate fields when a DataGrid row is clicked
        private void dataGridBilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is clicked
            if (e.RowIndex >= 0)
            {
                var row = dataGridBilling.Rows[e.RowIndex];

                // Ensure the Value is being properly set
                if (row.Cells["BookingID"].Value != DBNull.Value)
                {
                    int bookingID = Convert.ToInt32(row.Cells["BookingID"].Value);  // Convert to correct type
                    cbBookingID.SelectedValue = bookingID;  // Set ComboBox selected value
                }

                // Populate Amount Due and Amount Paid textboxes
                amttb.Text = row.Cells["Amount Due"].Value.ToString();
                amtpaidtb.Text = row.Cells["Amount Paid"].Value.ToString();

                // Set the Payment Status label based on row data
                paymentlabel.Text = row.Cells["Payment Status"].Value.ToString();
            }
        }

        private void btnDeleteTool_Click(object sender, EventArgs e)
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

       
    }
}
