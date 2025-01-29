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
    public partial class BookingsPage : Form
    {
        public BookingsPage()
        {
            InitializeComponent();
            BookingsTable.CellClick += BookingsTable_CellClick;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            ReadBookings();
        }

        private void ReadBookings()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("BookingReference");
            dataTable.Columns.Add("ClientName");            
            dataTable.Columns.Add("BookingDate");
            dataTable.Columns.Add("TotalAmount");

            var repo = new Bookingsrepository();
            var bookings = repo.GetBookings();

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

            this.BookingsTable.DataSource = dataTable;


            BookingsTable.ClearSelection();


            if (this.BookingsTable.Columns["BookingID"] != null)
            {
                this.BookingsTable.Columns["BookingID"].Visible = false;
            }

        }

        private void bookingsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookingsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.alexisconstructionDBDataSet);
        }

        private void BookingsPage_Load(object sender, EventArgs e)
        {
            this.bookingsTableAdapter.Fill(this.alexisconstructionDBDataSet.Bookings);
            LoadClientsDropdown();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            if (clientcmb.SelectedValue == null || !int.TryParse(clientcmb.SelectedValue.ToString(), out int clientId))
            {
                MessageBox.Show(ALEXISMessages.SelectValidClient);
                return;
            }

            DateTime newBookingDate = datetimepickertb.Value;

            // Check if the selected date is already booked for the same client
            var repo = new Bookingsrepository();
            bool isDateBooked = repo.IsDateBooked(clientId, newBookingDate);

            if (isDateBooked)
            {
                MessageBox.Show(ALEXISMessages.ClientBooked, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If date is not booked, proceed to create the booking
            Booking booking = new Booking
            {
                ClientID = clientId,
                BookingDate = newBookingDate
            };

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
                            MessageBox.Show(ALEXISMessages.BookingNotFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(ALEXISMessages.BookingNotValid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(ALEXISMessages.BookingNoSelect, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(ALEXISMessages.BookingNotSelect, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(ALEXISMessages.Selectrowtodelete, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var val = this.BookingsTable.SelectedRows[0].Cells[0].Value?.ToString();

            if (string.IsNullOrEmpty(val)) return;

            int bookingID = int.Parse(val);

            DialogResult dialogResult = MessageBox.Show(ALEXISMessages.Deleteconfirm, "Delete Booking", MessageBoxButtons.YesNo);
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
                MessageBox.Show(ALEXISMessages.Noclientsfound, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clientcmb.DataSource = clients;
            clientcmb.DisplayMember = "Name"; // Display the client name
            clientcmb.ValueMember = "ClientID";    // Store the ClientID in the value of ComboBox
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim(); // Get the search text

            var repo = new Bookingsrepository();
            var searchResults = repo.SearchBookings(searchText); // Search based on input

            // Update the DataGridView with the search results
            UpdateBookingTable(searchResults);
        }
        // Helper method to update the DataGridView with a list of bookings
        private void UpdateBookingTable(List<Booking> bookings)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("ClientName");
            dataTable.Columns.Add("BookingReference");
            dataTable.Columns.Add("BookingDate");
            dataTable.Columns.Add("TotalAmount");

            foreach (var booking in bookings)
            {
                var row = dataTable.NewRow();

                row["BookingID"] = booking.BookingID;
                row["ClientName"] = booking.ClientName;
                row["BookingReference"] = booking.BookingReference;
                row["BookingDate"] = booking.BookingDate;
                row["TotalAmount"] = booking.TotalAmount;

                dataTable.Rows.Add(row);
            }

            BookingsTable.DataSource = dataTable;

            // Hide the BookingID column
            if (BookingsTable.Columns["BookingID"] != null)
            {
                BookingsTable.Columns["BookingID"].Visible = false;
            }

            BookingsTable.ClearSelection(); // Clear selection after updating
        }
    }
}
