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
    public partial class BookingsPage : Form
    {
        public BookingsPage()
        {
            InitializeComponent();

            // Attach event handlers
            BookingsTable.CellClick += BookingsTable_CellClick;
        

            ReadBookings();
        }

        private void ReadBookings()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("ClientName");
            dataTable.Columns.Add("BookingDate");
            dataTable.Columns.Add("TotalAmount");

            var repo = new Bookingsrepository();
            var bookings = repo.GetBookings();

            foreach (var booking in bookings)
            {
                var row = dataTable.NewRow();

                row["BookingID"] = booking.BookingID;
                row["ClientName"] = booking.ClientName;
                row["BookingDate"] = booking.BookingDate;
                row["TotalAmount"] = booking.TotalAmount;

                dataTable.Rows.Add(row);
            }

            this.BookingsTable.DataSource = dataTable;

            // Clear the selection after refreshing the data
            BookingsTable.ClearSelection();

        }

        private void bookingsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookingsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.alexisconstructionDBDataSet);

        }

        private void BookingsPage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'alexisconstructionDBDataSet.Bookings' table. You can move, or remove it, as needed.
            this.bookingsTableAdapter.Fill(this.alexisconstructionDBDataSet.Bookings);
            LoadClientsDropdown();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            if (clientcmb.SelectedValue == null || !int.TryParse(clientcmb.SelectedValue.ToString(), out int clientId))
            {
                MessageBox.Show("Please select a valid Client.");
                return;
            }

            Booking booking = new Booking
            {
                ClientID = clientId,
                BookingDate = datetimepickertb.Value
            };

            var repo = new Bookingsrepository();
            repo.CreateBooking(booking);

            ReadBookings(); // Refresh the booking list
        }
      

        

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            if (BookingsTable.SelectedRows.Count > 0)
            {
                var row = BookingsTable.SelectedRows[0];

                if (row.Cells["BookingID"].Value != null)
                {
                    string bookingIDValue = row.Cells["BookingID"].Value.ToString();
                    Console.WriteLine($"Selected BookingID: {bookingIDValue}");

                    if (int.TryParse(bookingIDValue, out int bookingID))
                    {
                        var repo = new Bookingsrepository();
                        var booking = repo.GetBooking(bookingID);

                        if (booking != null)
                        {
                            BookingDetailsForm form = new BookingDetailsForm(booking);

                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                ReadBookings(); // Refresh the grid after editing
                                BookingsTable.ClearSelection(); // Reset the selection after closing the form
                            }
                        }
                        else
                        {
                            MessageBox.Show("Booking not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Booking ID is not a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No valid Booking ID found in the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No booking selected. Please select a booking to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void BookingsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row index is valid
            if (e.RowIndex >= 0 && e.RowIndex < BookingsTable.Rows.Count)
            {
                // Clear previous selection
                BookingsTable.ClearSelection();
                BookingsTable.Rows[e.RowIndex].Selected = true;

                var row = BookingsTable.Rows[e.RowIndex];

                // Safely extract row values
                var bookingIDValue = row.Cells["BookingID"].Value;
                var clientNameValue = row.Cells["ClientName"].Value;
                var bookingDateValue = row.Cells["BookingDate"].Value;
                var totalAmountValue = row.Cells["TotalAmount"].Value;

                // Log or use these values
                Console.WriteLine($"BookingID: {bookingIDValue}, ClientName: {clientNameValue}, BookingDate: {bookingDateValue}, TotalAmount: {totalAmountValue}");
            }
            else
            {
                // If the click is invalid, skip processing
                Console.WriteLine("Invalid row clicked.");
            }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Delete button clicked.");

            if (this.BookingsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var val = this.BookingsTable.SelectedRows[0].Cells[0].Value?.ToString();

            if (string.IsNullOrEmpty(val)) return;

            int bookingID = int.Parse(val);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Booking?", "Delete Booking", MessageBoxButtons.YesNo);
            Console.WriteLine($"Dialog result: {dialogResult}");

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var repo = new Bookingsrepository();
            repo.DeleteBooking(bookingID);

            ReadBookings();
        }
        private void LoadClientsDropdown()
        {
            var repo = new Clientrepository();
            var clients = repo.GetClients(); // Fetch all clients from the repository

            if (clients == null || clients.Count == 0)
            {
                MessageBox.Show("No clients found in the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clientcmb.DataSource = clients;
            clientcmb.DisplayMember = "Name"; // Display the client name
            clientcmb.ValueMember = "ClientID";    // Store the ClientID in the value of ComboBox
        }
    }
}
