using BOGSYDVDRENT.Controllers;
using System;
using System.Data;
using System.Windows.Forms;

namespace BOGSYDVDRENT.Views
{
    public partial class ReportsFormViews : Form
    {
        private readonly ReportsController _controller;
        private readonly CustomersController _customersController = new CustomersController();

        public ReportsFormViews()
        {
            InitializeComponent();
            _controller = new ReportsController();
        }
        private void btnViewRentals_Click(object sender, EventArgs e)
        {
            int? customerId = tbCustomer.Tag != null ? (int?)tbCustomer.Tag : null;
            DateTime? startDate = chkFilterDate.Checked ? (DateTime?)dtpStartDate.Value.Date : null;
            DateTime? endDate = chkFilterDate.Checked ? (DateTime?)dtpEndDate.Value.Date : null;

            DataTable dt = _controller.GetRentalReport(startDate, endDate, customerId);
            dataGridView1.DataSource = dt;
        }
        private void btnViewReturns_Click(object sender, EventArgs e)
        {
            int? customerId = tbCustomer.Tag != null ? (int?)tbCustomer.Tag : null;
            DateTime? startDate = chkFilterDate.Checked ? (DateTime?)dtpStartDate.Value.Date : null;
            DateTime? endDate = chkFilterDate.Checked ? (DateTime?)dtpEndDate.Value.Date : null;

            DataTable dt = _controller.GetReturnReport(startDate, endDate, customerId);
            dataGridView1.DataSource = dt;
        }
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerSelectViews();
            var result = customerForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var selectedClient = _customersController.GetCustomerByID(customerForm.SelectedClientID);
                if (selectedClient != null)
                {
                    tbCustomer.Text = selectedClient.Name;
                    tbCustomer.Tag = selectedClient.CustomerID;
                }
            }
        }
    }
}
