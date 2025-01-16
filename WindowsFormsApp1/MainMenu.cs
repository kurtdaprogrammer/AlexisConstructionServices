using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
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
    }
}
