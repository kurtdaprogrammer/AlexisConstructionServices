using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            ReadBookings();
        }

        private void ClientPage_Click(object sender, EventArgs e)
        {
            ClientPage clientPage = new ClientPage();
            clientPage.Show(); // Opens the ClientPage as a new window
        }

        private void Bookings_Click(object sender, EventArgs e)
        {
            BookingsPage bookingsPage = new BookingsPage();
            bookingsPage.Show(); // Opens the BookingsPage as a new window
        }

        private void Billings_Click(object sender, EventArgs e)
        {
            BillingPage billingPage = new BillingPage();
            billingPage.Show(); // Opens the BillingPage as a new window
        }

        private void Inventory_Click(object sender, EventArgs e)
        {
            InventoryPage inventoryPage = new InventoryPage();
            inventoryPage.Show(); // Opens the InventoryPage as a new window
        }

        private void Services_Click(object sender, EventArgs e)
        {
            ServicesPage servicePage = new ServicesPage();
            servicePage.Show(); // Opens the ServicePage as a new window
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'alexisconstructionDBDataSet.Bookings' table. You can move, or remove it, as needed.
            this.bookingsTableAdapter.Fill(this.alexisconstructionDBDataSet.Bookings);

        }

        private void ReadBookings()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("BookingID");
            dataTable.Columns.Add("ClientName");  // Add ClientName column
            dataTable.Columns.Add("BookingReference");  // Add BookingReference column
            dataTable.Columns.Add("BookingDate");
            dataTable.Columns.Add("TotalAmount");

            var repo = new Bookingsrepository();
            var bookings = repo.GetBookings();

            foreach (var booking in bookings)
            {
                var row = dataTable.NewRow();

                row["BookingID"] = booking.BookingID;
                row["ClientName"] = booking.ClientName; // Populate ClientName
                row["BookingReference"] = booking.BookingReference; // Populate BookingReference
                row["BookingDate"] = booking.BookingDate;
                row["TotalAmount"] = booking.TotalAmount;

                dataTable.Rows.Add(row);
            }

            this.MainmenuDGT.DataSource = dataTable;

            // Clear the selection after refreshing the data
            MainmenuDGT.ClearSelection();

            // Optionally, hide the BookingID column
            if (this.MainmenuDGT.Columns["BookingID"] != null)
            {
                this.MainmenuDGT.Columns["BookingID"].Visible = false;
            }

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            ReadBookings();
        }
    }
}
