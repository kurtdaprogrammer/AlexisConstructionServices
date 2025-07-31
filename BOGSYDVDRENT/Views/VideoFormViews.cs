using BOGSYDVDRENT.Controllers;
using BOGSYDVDRENT.Helpers;
using Microsoft.Data.SqlClient;
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
    public partial class VideoFormViews : Form
    {
        private readonly VideosController _videoscontroller;

        public VideoFormViews()
        {
            InitializeComponent();
            _videoscontroller = new VideosController();
            LoadVideosToGrid();
            videoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            videoDataGridView.MultiSelect = false;
            videoDataGridView.CellClick += videoDataGridView_CellClick;
            btnEditVideo.Click += btnEditVideo_Click;

        }
        private void VideoFormViews_Load(object sender, EventArgs e)
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("VCD");
            cbCategory.Items.Add("DVD");
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem != null)
            {
                if (cbCategory.SelectedItem.ToString() == "VCD")
                    tbRentalRate.Text = "25";
                else if (cbCategory.SelectedItem.ToString() == "DVD")
                    tbRentalRate.Text = "50";
            }
        }
        private void LoadVideosToGrid()
        {
            VideosController repo = new VideosController();
            var videos = repo.GetVideos();
            videoDataGridView.DataSource = videos;
            videoDataGridView.ClearSelection();
        }
        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbVideoname.Text) ||
        cbCategory.SelectedItem == null ||
        string.IsNullOrWhiteSpace(tbRentalRate.Text))
            {
                MessageBox.Show("Please complete all video fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Videos videos = new Videos
            {
                Title = tbVideoname.Text.Trim(),
                Category = cbCategory.SelectedItem.ToString(),
                RentalRate = decimal.Parse(tbRentalRate.Text.Trim()),
                MaxRentalDays = (int)numMaxDays.Value,
                TotalQuantity = (int)numQuantity.Value
            };

            _videoscontroller.AddVideo(videos);
            LoadVideosToGrid();
            ClearVideoFormFields();
        }
        private void ClearVideoFormFields()
        {
            tbVideoname.Text = "";
            cbCategory.SelectedIndex = -1;
            tbRentalRate.Text = "";
            numMaxDays.Value = 1;
            numQuantity.Value = 1;
        }
        private void btnEditVideo_Click(object sender, EventArgs e)
        {
            if (videoDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a video to edit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbVideoname.Text) ||
                cbCategory.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tbRentalRate.Text))
            {
                MessageBox.Show("Please complete all video fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = Convert.ToInt32(videoDataGridView.SelectedRows[0].Cells["VideoID"].Value);

            Videos video = new Videos
            {
                VideoID = selectedId,
                Title = tbVideoname.Text.Trim(),
                Category = cbCategory.SelectedItem.ToString(),
                RentalRate = decimal.Parse(tbRentalRate.Text.Trim()),
                MaxRentalDays = (int)numMaxDays.Value,
                TotalQuantity = (int)numQuantity.Value
            };

            _videoscontroller.EditVideo(video);
            MessageBox.Show("Video updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadVideosToGrid();
            ClearVideoFormFields();
        }
        private void btnDeleteVideo_Click(object sender, EventArgs e)
        {
            DialogResult result = Helper.ValidateDelete();
            if (result == DialogResult.Yes)
            {
                if (videoDataGridView.SelectedRows.Count > 0)
                {
                    int selectedId = Convert.ToInt32(videoDataGridView.SelectedRows[0].Cells["VideoID"].Value);

                    VideosController repo = new VideosController(); // FIXED: use the correct controller
                    repo.DeleteVideo(selectedId); // FIXED: call DeleteVideo, not DeleteCustomer

                    MessageBox.Show("Video deleted successfully!");
                    LoadVideosToGrid();
                }
                else
                {
                    MessageBox.Show("Please select a Video to delete.");
                }
            }
        }
        private void videoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = videoDataGridView.Rows[e.RowIndex];

                tbVideoname.Text = row.Cells["Title"].Value?.ToString();
                cbCategory.SelectedItem = row.Cells["Category"].Value?.ToString();
                tbRentalRate.Text = row.Cells["RentalRate"].Value?.ToString();
                numMaxDays.Value = Convert.ToInt32(row.Cells["MaxRentalDays"].Value);
                numQuantity.Value = Convert.ToInt32(row.Cells["TotalQuantity"].Value);
            }
        }
    }
}
