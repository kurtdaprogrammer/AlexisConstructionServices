using BOGSYDVDRENT.Controllers;
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
    public partial class CustomerSelectViews : Form
    {
        public string SelectedClientName { get; private set; }
        public int SelectedClientID { get; private set; }
        public CustomerSelectViews()
        {
            InitializeComponent();
            LoadCustomersToGrid();
            Customersdg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Customersdg.MultiSelect = false;
        }
        private void Customersdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelectCustomer.Enabled = Customersdg.SelectedRows.Count > 0;
        }
        private void LoadCustomersToGrid()
        {
            CustomersController repo = new CustomersController();
            var customers = repo.GetCustomers();
            Customersdg.DataSource = customers;
            Customersdg.ClearSelection();
        }
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            if (Customersdg.SelectedRows.Count > 0)
            {
                var row = Customersdg.SelectedRows[0];
                SelectedClientID = Convert.ToInt32(row.Cells["CustomerID"].Value);
                SelectedClientName = row.Cells["Name"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a customer from the list.");
            }
        }

    }
}
