using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Helpers
{
    public class Helper
    {
        public static void ValidateDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static DialogResult ValidateDelete()
        {
            return MessageBox.Show("Are you sure you want to delete this Value?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
