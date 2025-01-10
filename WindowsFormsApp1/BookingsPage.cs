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

        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            booking.ClientID = int.Parse(ClientTb.Text);  
            booking.BookingDate = datetimepickertb.Value;  
            booking.TotalAmount = decimal.Parse(totalamounttb.Text);


            if (string.IsNullOrEmpty(ClientTb.Text) || string.IsNullOrEmpty(totalamounttb.Text))
            {
                MessageBox.Show("There are empty fields. Please enter a Fill the Values.");
                return;
            }

            var repo = new Bookingsrepository();
            if (booking.BookingID == 0)
            {
                repo.CreateBooking(booking);
                ReadBookings();
            }
            // else
            //  {
            //     repo.UpdateClient(client);
            // }
        }
    }
}
