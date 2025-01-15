using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class InventoryPage : Form
    {
        public InventoryPage()
        {
            InitializeComponent();

            ReadInventory();
        }

        private void ReadInventory()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ToolID");
            dataTable.Columns.Add("Tool Name");
            dataTable.Columns.Add("Service Name");
            dataTable.Columns.Add("Quantity Available");

            var repo = new InventoryRepository();
            var Inventory = repo.GetInventory();

            foreach (var inventory in Inventory)
            {
                var row = dataTable.NewRow();

                row["ToolID"] = inventory.ToolID;
                row["Tool Name"] = inventory.ToolName;
                row["Service Name"] = inventory.ServiceID;
                row["Quantity Available"] = inventory.QuantityAvailable;

                dataTable.Rows.Add(row);
            }

            this.dataGridInventory.DataSource = dataTable;

        }

    }
}
