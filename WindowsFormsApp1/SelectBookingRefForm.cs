using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class SelectBookingRefForm : Form
    {
        public string SelectedBookingReference { get; private set; }
        public int SelectedBookingID { get; private set; }
        public string ClientName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal AmountPaid { get; private set; }

        public SelectBookingRefForm()
        {
            InitializeComponent();
            bookingview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Searchbox.TextChanged += new EventHandler(this.Searchbox_TextChanged); // Attach the TextChanged event
            ReadBookings(); // Initial load of all bookings
        }

        // Method to read and display bookings with optional filtering
        private void ReadBookings(string searchQuery = "")
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("BookingReference");
            dataTable.Columns.Add("ClientName");
            dataTable.Columns.Add("BookingDate");
            dataTable.Columns.Add("TotalAmount");

            var repo = new Bookingsrepository();
            var bookings = repo.GetBookings(); // Get all bookings

            // If a search query is provided, filter the bookings
            if (!string.IsNullOrEmpty(searchQuery))
            {
                bookings = bookings.Where(booking =>
                    booking.BookingReference.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    booking.ClientName.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    booking.TotalAmount.ToString().Contains(searchQuery)
                ).ToList();
            }

            // Add filtered bookings to the DataTable
            foreach (var booking in bookings)
            {
                var row = dataTable.NewRow();
                row["BookingReference"] = booking.BookingReference ?? "N/A";
                row["BookingID"] = booking.BookingID;
                row["ClientName"] = booking.ClientName;
                row["BookingDate"] = booking.BookingDate;
                row["TotalAmount"] = booking.TotalAmount;
                dataTable.Rows.Add(row);
            }

            // Bind DataTable to DataGridView
            this.bookingview.DataSource = dataTable;

            // Optionally hide the BookingID column
            if (this.bookingview.Columns["BookingID"] != null)
            {
                this.bookingview.Columns["BookingID"].Visible = false;
            }
        }

        // Event handler for when the user types in the Searchbox
        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = Searchbox.Text.Trim();
            ReadBookings(searchQuery); // Call ReadBookings with the search query to filter the results
        }

        // Event handler for when a booking is selected in the DataGridView
        private void BookingSel_Click(object sender, EventArgs e)
        {
            if (bookingview.SelectedRows.Count > 0)
            {
                var selectedRow = bookingview.SelectedRows[0];

                // Get the values from the selected row
                SelectedBookingReference = selectedRow.Cells["BookingReference"].Value.ToString();
                SelectedBookingID = Convert.ToInt32(selectedRow.Cells["BookingID"].Value);
                ClientName = selectedRow.Cells["ClientName"].Value.ToString(); // Get client name
                TotalAmount = Convert.ToDecimal(selectedRow.Cells["TotalAmount"].Value); // Get amount due

                // Close the form with OK result
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a booking.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Event handler for the Cancel button
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
