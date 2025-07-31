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
    public partial class RentalFormViews : Form
    {
        private readonly CustomersController _customersController = new CustomersController();
        private readonly VideosController _videosController = new VideosController();
        private List<RentalItem> _rentalItems = new List<RentalItem>();
        private readonly RentalControllers _rentalController = new RentalControllers();
        private readonly RentalDetailsController _rentalDetailsController = new RentalDetailsController();
        private Videos _selectedVideo;


        public RentalFormViews()
        {
            InitializeComponent();
            LoadAvailableVideos();
            dgvAvailableVideos.CellClick += dgvAvailableVideos_CellClick;
            dgvAvailableVideos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableVideos.MultiSelect = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.MultiSelect = false;

        }
        private void AddClient_Click(object sender, EventArgs e)
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
        private void btnAddToCart_Click(object sender, EventArgs e)
        {

            if (_selectedVideo == null)
            {
                MessageBox.Show("Please select a video first.");
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Please enter a quantity greater than 0.");
                return;
            }

            int quantity = (int)numQuantity.Value;


            var existingItem = _rentalItems.FirstOrDefault(x => x.VideoID == _selectedVideo.VideoID);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _rentalItems.Add(new RentalItem
                {
                    VideoID = _selectedVideo.VideoID,
                    VideoTitle = _selectedVideo.Title,
                    Quantity = quantity,
                    RentalRate = _selectedVideo.RentalRate
                });
            }

            dgvCart.DataSource = null;
            dgvCart.DataSource = _rentalItems;

            UpdateTotal();
        }
        private void UpdateTotal()
        {
            decimal total = _rentalItems.Sum(i => i.Subtotal);
            lblTotalAmount.Text = total.ToString("C");
        }
        private void btnSaveRental_Click(object sender, EventArgs e)
        {
            if (_rentalItems.Count == 0 || tbCustomer.Tag == null || numQuantity.Value <= 0) return;

            int customerId = (int)tbCustomer.Tag;
            DateTime rentalDate = dtRentalDate.Value;
            DateTime dueDate = dtDueDate.Value;
            decimal totalAmount = _rentalItems.Sum(i => i.Subtotal);

            var rentalId = _rentalController.AddRental(customerId, rentalDate, dueDate, totalAmount);

            foreach (var item in _rentalItems)
            {
                _rentalDetailsController.AddRentalDetail(rentalId, item.VideoID, item.Quantity, item.RentalRate);
            }

            MessageBox.Show("Rental saved successfully!");
            _rentalItems.Clear();
            _selectedVideo = null;
            dgvCart.DataSource = null;
            UpdateTotal();
        }
        private void LoadAvailableVideos()
        {
            var videos = _videosController.GetVideos();
            dgvAvailableVideos.DataSource = null;
            dgvAvailableVideos.DataSource = videos;
        }
        private void dgvAvailableVideos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedVideo = dgvAvailableVideos.Rows[e.RowIndex].DataBoundItem as Videos;
            }
        }
        private void Removetocartbt_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            var selectedItem = dgvCart.CurrentRow.DataBoundItem as RentalItem;
            if (selectedItem != null)
            {
                _rentalItems.Remove(selectedItem);
                dgvCart.DataSource = null;
                dgvCart.DataSource = _rentalItems;
                UpdateTotal();
            }
        }
    }
}
