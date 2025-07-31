using Alexisconstructionerp.Controllers;
using Alexisconstructionerp.Helper;
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

    public partial class Inventoryform : Form
    {
        private readonly Inventorycontroller _inventorycontroller;
        public Inventoryform()
        {
            InitializeComponent();
            LoadInventoriesToGrid();
            _inventorycontroller = new Inventorycontroller();
            this.Shown += Inventory_Shown;
            InventoryDataGrid.CellClick += InventoryDataGrid_CellClick;

        }
        private void LoadInventoriesToGrid()
        {
            Inventorycontroller repo = new Inventorycontroller();
            var inventories = repo.GetInventories();
            InventoryDataGrid.DataSource = inventories;
            InventoryDataGrid.ClearSelection();
            InventoryDataGrid.CurrentCell = null;
        }
        private void Addinventorybt_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Inventoryqtytb.Text.Trim(), out decimal qty))
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Inventory inventory = new Inventory
            {
                Tool_name = Inventorynametb.Text.Trim(),
                Tool_Qty = qty
            };
            _inventorycontroller.AddInventory(inventory);
            LoadInventoriesToGrid();
        }
        private void Inventoryqtytb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.Helper.ValidateDigit(sender, e);
        }
        private void Deleteinventorybt_Click(object sender, EventArgs e)
        {
            DialogResult result = Helper.Helper.ValidateDelete();
            if (result == DialogResult.Yes)
            {
                if (InventoryDataGrid.SelectedRows.Count > 0)
                {
                    int selectedId = Convert.ToInt32(InventoryDataGrid.SelectedRows[0].Cells["Inventory_ID"].Value);

                    Inventorycontroller repo = new Inventorycontroller();
                    repo.DeleteInventory(selectedId);

                    MessageBox.Show("Item deleted successfully!");
                    LoadInventoriesToGrid();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
        }
        private void Editinventorybt_Click(object sender, EventArgs e)
        {
            if (InventoryDataGrid.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(Inventorynametb.Text) || string.IsNullOrWhiteSpace(Inventoryqtytb.Text))
            {
                MessageBox.Show("Please select an inventory item to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var row = InventoryDataGrid.SelectedRows[0];

                Inventory inventory = new Inventory
                {
                    Inventory_ID = Convert.ToInt32(row.Cells["Inventory_ID"].Value),
                    Tool_name = Inventorynametb.Text.Trim(),
                    Tool_Qty = Convert.ToDecimal(Inventoryqtytb.Text.Trim())
                };
                Inventorycontroller controller = new Inventorycontroller();
                controller.EditInventory(inventory);
            }

            LoadInventoriesToGrid();
        }
        private void InventoryDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = InventoryDataGrid.Rows[e.RowIndex];

                Inventorynametb.Text = row.Cells["Tool_name"].Value?.ToString().Trim();
                Inventoryqtytb.Text = row.Cells["Tool_Qty"].Value?.ToString().Trim();
            }
        }
        private void InventoryDataGrid_SelectionChanged_1(object sender, EventArgs e)
        {
            if (InventoryDataGrid.SelectedRows.Count > 0)
            {
                var row = InventoryDataGrid.SelectedRows[0];
                Inventorynametb.Text = row.Cells["Tool_name"].Value?.ToString().Trim();
                Inventoryqtytb.Text = row.Cells["Tool_Qty"].Value?.ToString().Trim();
            }
        }
        private void Inventory_Shown(object sender, EventArgs e)
        {
            InventoryDataGrid.ClearSelection(); 
        }
    }
}
