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
        private Bookingsrepository bookingsRepo = new Bookingsrepository();
        public BillingPage()
        {
            InitializeComponent();
            LoadBookingsDropdown();
            cbBookingID.SelectedIndexChanged += cbBookingID_SelectedIndexChanged;
            LoadBillingData();
        }
        // Load Billing data into DataGridView
        private void LoadBillingData()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("BillingID");
            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("BillingReference");  // Add BillingReference column
            dataTable.Columns.Add("AmountDue");
            dataTable.Columns.Add("AmountPaid");
            dataTable.Columns.Add("PaymentStatus");

            var repo = new BillingRepository();
            var billings = repo.GetBillings();

            foreach (var billing in billings)
            {
                var row = dataTable.NewRow();

                row["BillingID"] = billing.BillingID;
                row["BookingID"] = billing.BookingID;
                row["BillingReference"] = billing.BillingReference ?? "N/A";  // Ensure null is handled
                row["AmountDue"] = billing.AmountDue;
                row["AmountPaid"] = billing.AmountPaid;
                row["PaymentStatus"] = billing.PaymentStatus;

                dataTable.Rows.Add(row);
            }

            this.dataGridBilling.DataSource = dataTable;

            // Clear the selection after refreshing the data
            dataGridBilling.ClearSelection();

            
            if (this.dataGridBilling.Columns["BookingID"] != null)
            {
                this.dataGridBilling.Columns["BookingID"].Visible = false;
            }
            if (this.dataGridBilling.Columns["BillingID"] != null)
            {
                this.dataGridBilling.Columns["BillingID"].Visible = false;
            }


        }
        // Load Booking IDs into ComboBox
        private void LoadBookingsDropdown()
        {
            var bookings = bookingsRepo.GetBookings(); // Get all bookings from the repository

            // Bind the ComboBox to the list of bookings
            cbBookingID.DataSource = bookings;
            cbBookingID.DisplayMember = "BookingID";  // Display BookingID in the dropdown
            cbBookingID.ValueMember = "BookingID";    // Use BookingID as the ValueMember to bind
        }
        // Event Handler to Display Amount Due for Selected Booking
        private void cbBookingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBookingID.SelectedValue == null)
                return;

            int selectedBookingID = Convert.ToInt32(cbBookingID.SelectedValue);

            // Fetch the corresponding booking details
            var booking = bookingsRepo.GetBooking(selectedBookingID);

            // If booking is found, set the Client Name and Amount Due
            if (booking != null)
            {
                ClientNametb.Text = booking.ClientName; // Display the Client Name
                amttb.Text = booking.TotalAmount.ToString("0.00"); // Display the Total Amount as Amount Due
            }
            else
            {
                ClientNametb.Text = ""; // Default to empty if booking is not found
                amttb.Text = "0.00"; // Default to "0.00" if Amount Due is not found
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
                    return;
                }

                // Check if Amount Paid is entered, if not, set it to 0
                decimal amountPaid = string.IsNullOrEmpty(amtpaidtb.Text) ? 0 : decimal.Parse(amtpaidtb.Text);

                // Check if Amount Paid is greater than or equal to Amount Due
                decimal amountDue = decimal.Parse(amttb.Text);
                string paymentStatus = amountPaid >= amountDue ? "Paid" : "Pending";

                // Set the label to show the payment status
                paymentlabel.Text = paymentStatus;

                // Generate a unique BillingReference
                string billingReference = "BILL-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Create a new Billing object
                Billing billing = new Billing
                {
                    BookingID = Convert.ToInt32(cbBookingID.SelectedValue),
                    AmountDue = amountDue,
                    AmountPaid = amountPaid,
                    PaymentStatus = paymentStatus,
                    BillingReference = billingReference
                };

                // Call the repository to create the billing record
                billingRepo.CreateBilling(billing);

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
            if (dataGridBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridBilling.SelectedRows[0];
            int billingID = Convert.ToInt32(selectedRow.Cells["BillingID"].Value);

            try
            {
                // Check if BookingID is selected
                if (cbBookingID.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a booking from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal amountPaid = string.IsNullOrEmpty(amtpaidtb.Text) ? 0 : decimal.Parse(amtpaidtb.Text);
                decimal amountDue = decimal.Parse(amttb.Text);

                if (amountDue <= 0)
                {
                    MessageBox.Show("Amount Due should be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string paymentStatus = amountPaid >= amountDue ? "Paid" : "Pending";
                paymentlabel.Text = paymentStatus;

                Billing billing = new Billing
                {
                    BillingID = billingID,
                    BookingID = Convert.ToInt32(cbBookingID.SelectedValue),
                    AmountDue = amountDue,
                    AmountPaid = amountPaid,
                    PaymentStatus = paymentStatus
                };

                billingRepo.UpdateBilling(billing);

                MessageBox.Show("Billing record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBillingData();

                ClearFields(); // Clear fields after updating
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
            // Ensure the clicked row index is valid
            if (e.RowIndex >= 0 && e.RowIndex < dataGridBilling.Rows.Count)
            {
                // Clear previous selection
                dataGridBilling.ClearSelection();
                dataGridBilling.Rows[e.RowIndex].Selected = true;

                var row = dataGridBilling.Rows[e.RowIndex];

                // Safely extract row values
                var bookingIDValue = row.Cells["BookingID"].Value;
                var billingReferenceValue = row.Cells["BillingReference"].Value;
                var amountDueValue = row.Cells["AmountDue"].Value;
                var amountPaidValue = row.Cells["AmountPaid"].Value;
                var paymentStatusValue = row.Cells["PaymentStatus"].Value;

                // Log or use these values for debugging
                Console.WriteLine($"BookingID: {bookingIDValue}, BillingReference: {billingReferenceValue}, AmountDue: {amountDueValue}, AmountPaid: {amountPaidValue}, PaymentStatus: {paymentStatusValue}");

                // Set the ComboBox value to the BookingID from the row
                cbBookingID.SelectedValue = bookingIDValue; // Select the appropriate BookingID in the ComboBox

                // Manually trigger the SelectedIndexChanged event to update textboxes
                cbBookingID_SelectedIndexChanged(sender, e);

                // Populate the textboxes and labels with this billing data
                amttb.Text = amountDueValue.ToString(); // Amount Due
                amtpaidtb.Text = amountPaidValue.ToString(); // Amount Paid
                paymentlabel.Text = paymentStatusValue.ToString(); // Payment Status

                // If you want to populate the Client Name, you should fetch the booking details using the BookingID
                var booking = bookingsRepo.GetBooking(Convert.ToInt32(bookingIDValue));

                if (booking != null)
                {
                    ClientNametb.Text = booking.ClientName; // Set the client name from the booking
                }
                else
                {
                    ClientNametb.Clear(); // Clear the client name textbox if no booking is found
                }
            }
        }
     
        private void ClearFields()
        {
            cbBookingID.SelectedIndex = -1; // Clear ComboBox selection
            amttb.Clear(); // Clear Amount Due textbox
            amtpaidtb.Clear(); // Clear Amount Paid textbox
            paymentlabel.Text = ""; // Clear Payment Status label
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
    }
}
