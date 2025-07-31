using Alexisconstructionerp.Controllers;
using Alexisconstructionerp.Models;
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
    public partial class BookingsForm : Form
    {
        public BookingsForm()
        {
            InitializeComponent();
            Statuscb.DataSource = Enum.GetValues(typeof(BookingStatus));
            LoadBookings();

        }
        private int selectedClientId = 0;
   
        private void button1_Click(object sender, EventArgs e)
        {
            using (var clientForm = new AddClienttoBookingform())
            {
                if (clientForm.ShowDialog() == DialogResult.OK)
                {
                    selectedClientId = clientForm.SelectedClientId;
                    Clientselectedtb.Text = clientForm.SelectedClientName;
                    addservicebtn.Visible = true;
                    submitbookingbtn.Visible = true;
                    Statuscb.Visible = true;
                    textBox1.Visible = true;
                    dateTimePicker1.Visible = true;
                }
            }
        }

        private void addservicebtn_Click(object sender, EventArgs e)
        {
            var newBooking = new Bookings
            {
                Client_ID = selectedClientId,
                Booking_Date = dateTimePicker1.Value,
                Status = Statuscb.SelectedItem.ToString(),
                Remarks = textBox1.Text
            };

            Bookingscontroller controller = new Bookingscontroller();
            controller.AddBooking(newBooking);

            MessageBox.Show("Booking added!");
            LoadBookings(); // refresh grid
        }

      

        private void submitbookingbtn_Click(object sender, EventArgs e)
        {
            if (selectedClientId == 0)
            {
                MessageBox.Show("Please select a client.");
                return;
            }

            Bookingscontroller controller = new Bookingscontroller();
            Bookings booking = new Bookings
            {
                Client_ID = selectedClientId,
                Booking_Date = dateTimePicker1.Value,
                Status = Statuscb.SelectedItem.ToString(),
                Remarks = textBox1.Text
            };

            controller.AddBooking(booking);

            MessageBox.Show("Booking added successfully.");
            LoadBookings(); // refresh datagrid
        }
        private void LoadBookings()
        {
            Bookingscontroller controller = new Bookingscontroller();
            var bookings = controller.GetBookingsWithClientName();
            bookingsdatagrid.DataSource = bookings;
            bookingsdatagrid.ClearSelection();
        }

    }
}
