using BOGSYDVDRENT.Controllers;
using BOGSYDVDRENT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOGSYDVDRENT.Views
{
    public partial class ReturnFormViews : Form
    {
        private readonly CustomersController _customersController = new CustomersController();
        private readonly RentalControllers _rentalController = new RentalControllers();
        private readonly ReturnsController _returnController = new ReturnsController();
        private int _selectedCustomerId;
        private readonly ReturnDetailsController _returnDetailsController = new ReturnDetailsController();

        public ReturnFormViews()
        {
            InitializeComponent();
            dgvCurrentRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrentRentals.MultiSelect = false;
            dgvCurrentRentals.SelectionChanged += (s, e) => UpdatePenaltyDisplay();
            dtpReturnDate.ValueChanged += (s, e) => UpdatePenaltyDisplay();
        }
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            var selectForm = new CustomerSelectViews();
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                var customer = _customersController.GetCustomerByID(selectForm.SelectedClientID);
                if (customer != null)
                {
                    _selectedCustomerId = customer.CustomerID;
                    tbCustomer.Text = customer.Name;
                    LoadCustomerRentals();
                }
            }
        }
        private void LoadCustomerRentals()
        {
            var rentals = _returnDetailsController.GetUnreturnedRentalsByCustomer(_selectedCustomerId);
            dgvCurrentRentals.DataSource = rentals;


            dgvCurrentRentals.Columns["RentalDetailID"].Visible = false;
            dgvCurrentRentals.Columns["RentalID"].Visible = false;
            dgvCurrentRentals.Columns["VideoID"].Visible = false;

            dgvCurrentRentals.Columns["VideoTitle"].HeaderText = "Video Title";
            dgvCurrentRentals.Columns["RentalDate"].HeaderText = "Rented On";
            dgvCurrentRentals.Columns["DueDate"].HeaderText = "Due Date";
            dgvCurrentRentals.Columns["Quantity"].HeaderText = "Qty";
            dgvCurrentRentals.Columns["Rate"].HeaderText = "Rate (₱)";
        }
        private void btnReturnSelected_Click(object sender, EventArgs e)
        {
            if (dgvCurrentRentals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rental to return.");
                return;
            }

            var rentalItem = (RentalDetailView)dgvCurrentRentals.SelectedRows[0].DataBoundItem;
            DateTime returnDate = dtpReturnDate.Value;

            decimal penalty = 0;
            if (returnDate > rentalItem.DueDate)
            {
                int overdueDays = (returnDate - rentalItem.DueDate).Days;
                penalty = overdueDays * rentalItem.Rate;
            }

            _returnController.ProcessReturn(rentalItem.RentalDetailID, returnDate, penalty);

            MessageBox.Show("Return successful!");
            LoadCustomerRentals();
        }
        private void UpdatePenaltyDisplay()
        {
            if (dgvCurrentRentals.SelectedRows.Count == 0)
            {
                lblPenalty.Text = "Penalty: ₱0";
                return;
            }

            var rentalItem = (RentalDetailView)dgvCurrentRentals.SelectedRows[0].DataBoundItem;
            DateTime returnDate = dtpReturnDate.Value;

            decimal penalty = 0;
            if (returnDate > rentalItem.DueDate)
            {
                int overdueDays = (returnDate - rentalItem.DueDate).Days;
                penalty = overdueDays * rentalItem.Rate;
            }

            lblPenalty.Text = $"Penalty: ₱{penalty}";
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
