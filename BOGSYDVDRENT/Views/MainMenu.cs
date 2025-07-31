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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerViews form = new CustomerViews();
            form.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VideoFormViews form = new VideoFormViews();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RentalFormViews form = new RentalFormViews();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReturnFormViews form = new ReturnFormViews();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReportsFormViews form = new ReportsFormViews();
            form.ShowDialog();
        }
    }
}
