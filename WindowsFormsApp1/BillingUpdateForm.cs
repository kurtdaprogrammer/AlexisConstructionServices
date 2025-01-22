using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Messages;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class BillingUpdateForm : Form
    {
        private int billingID;
        private int bookingID;
        private string billingReference;
        private decimal amountDue;
        private decimal amountPaid;
        private string paymentStatus;
        private BillingRepository billingRepo = new BillingRepository();

        public BillingUpdateForm(int billingID, int bookingID, string billingReference, decimal amountDue, decimal amountPaid, string paymentStatus, string clientName)
        {
            InitializeComponent();

            // Store values
            this.billingID = billingID;
            this.bookingID = bookingID;
            this.billingReference = billingReference;
            this.amountDue = amountDue;
            this.amountPaid = amountPaid;
            this.paymentStatus = paymentStatus;

            // Populate the form controls with passed values
            lbbillingreference.Text = billingReference;
            Amtdue.Text = amountDue.ToString("0.00");
            Amtpaid.Text = amountPaid.ToString("0.00");
            Nametb.Text = clientName;

            // Display Payment Status in the label (pmtlbl)
            pmtlbl.Text = paymentStatus;
        }
        public BillingUpdateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate and collect data from the form
                decimal newAmountDue = decimal.Parse(Amtdue.Text);
                decimal newAmountPaid = decimal.Parse(Amtpaid.Text);

                // Calculate PaymentStatus based on AmountPaid and AmountDue
                string newPaymentStatus = newAmountPaid >= newAmountDue ? "Paid" : "Pending";

                // Update the billing record
                Billing updatedBilling = new Billing
                {
                    BillingID = this.billingID,
                    BookingID = this.bookingID,
                    BillingReference = this.billingReference,
                    AmountDue = newAmountDue,
                    AmountPaid = newAmountPaid,
                    PaymentStatus = newPaymentStatus // Set the calculated PaymentStatus
                };

                // Call the repository to update the billing record
                billingRepo.UpdateBilling(updatedBilling);

                MessageBox.Show(ALEXISMessages.Billinggupdatesuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show(ALEXISMessages.Invalidnumeric, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating billing record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Optionally, you can reset the values in the form
            Amtdue.Clear();
            Amtpaid.Clear();
           

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
