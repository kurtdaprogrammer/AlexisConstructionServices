using BOGSYDVDRENT.Controllers;
using BOGSYDVDRENT.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOGSYDVDRENT.Views
{
    public partial class CustomerViews : Form
    {
        private readonly CustomersController _customerscontroller;

        public CustomerViews()
        {
            InitializeComponent();
            _customerscontroller = new CustomersController();
            LoadCustomersToGrid();
            Customersdg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Customersdg.MultiSelect = false;
            this.Shown += Customer_Shown;
            Customersdg.CellClick += CustomersdgGrid_CellClick;
        }

        private void btaddcustomer_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers
            {
                Name = tbcustomerfname.Text.Trim(),
                ContactNumber = tbcustomercontactnumber.Text.Trim(),
                Address = tbcustomeraddress.Text.Trim()
            };
            _customerscontroller.AddCustomer(customers);
            LoadCustomersToGrid();
        }
        private void LoadCustomersToGrid()
        {
            CustomersController repo = new CustomersController();
            var customers = repo.GetCustomers();
            Customersdg.DataSource = customers;
            Customersdg.ClearSelection();
        }
        private void btdeletecustomer_Click(object sender, EventArgs e)
        {
            DialogResult result = Helper.ValidateDelete();
            if (result == DialogResult.Yes)
            {
                if (Customersdg.SelectedRows.Count > 0)
                {
                    int selectedId = Convert.ToInt32(Customersdg.SelectedRows[0].Cells["CustomerID"].Value);

                    CustomersController repo = new CustomersController();
                    repo.DeleteCustomer(selectedId);

                    MessageBox.Show("Client deleted successfully!");
                    LoadCustomersToGrid();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }

            }
        }
        private void bteditcustomer_Click(object sender, EventArgs e)
        {
            if (Customersdg.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(tbcustomerfname.Text) || string.IsNullOrWhiteSpace(tbcustomercontactnumber.Text) || string.IsNullOrWhiteSpace(tbcustomeraddress.Text))
            {
                MessageBox.Show("Please select a Customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var row = Customersdg.SelectedRows[0];

                Customers customers = new Customers
                {
                    CustomerID = Convert.ToInt32(row.Cells["CustomerID"].Value),
                    Name = tbcustomerfname.Text.Trim(),
                    ContactNumber = tbcustomercontactnumber.Text.Trim(),
                    Address = tbcustomeraddress.Text.Trim()
                };
                CustomersController controller = new CustomersController();
                controller.EditCustomer(customers);
            }

            LoadCustomersToGrid();
        }
        private void CustomersdgGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Customersdg.Rows[e.RowIndex];

                tbcustomerfname.Text = row.Cells["Name"].Value?.ToString().Trim();
                tbcustomercontactnumber.Text = row.Cells["ContactNumber"].Value?.ToString().Trim();
                tbcustomeraddress.Text = row.Cells["Address"].Value?.ToString().Trim();
            }
        }
        private void Customersdg_SelectionChanged_1(object sender, EventArgs e)
        {
            if (Customersdg.SelectedRows.Count > 0)
            {
                var row = Customersdg.SelectedRows[0];
                tbcustomerfname.Text = row.Cells["Name"].Value?.ToString().Trim();
                tbcustomercontactnumber.Text = row.Cells["ContactNumber"].Value?.ToString().Trim();
                tbcustomeraddress.Text = row.Cells["Address"].Value?.ToString().Trim();
            }
        }
        private void Customer_Shown(object sender, EventArgs e)
        {
            Customersdg.ClearSelection();
        }
    }
}
