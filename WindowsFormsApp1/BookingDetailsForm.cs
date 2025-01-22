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
    public partial class BookingDetailsForm : Form
    {
        private Booking _currentBooking;
        private ServiceDetail _selectedServiceDetail;
        public BookingDetailsForm(Booking booking)
        {
            InitializeComponent();
            _currentBooking = booking;
            LoadServicesToGrid();
        }

        private void BookingDetailsForm_Load(object sender, EventArgs e)
        {
            if (_currentBooking == null)
            {
                MessageBox.Show(ALEXISMessages.Bookingnotload, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Prevent further execution
            }

           
            clienttb.Text = _currentBooking.ClientName;
            bookingtb.Value = _currentBooking.BookingDate;
            totalamounttb.Text = _currentBooking.TotalAmount.ToString("F2");

            LoadServicesDropdown();

            // Wire up the SelectedIndexChanged event for ComboBox
            servicecmb.SelectedIndexChanged += servicecmb_SelectedIndexChanged;
        }



        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            // Updating _currentBooking with the new values from the form
            _currentBooking.ClientName = clienttb.Text;
            _currentBooking.BookingDate = bookingtb.Value;
            _currentBooking.TotalAmount = decimal.Parse(totalamounttb.Text);

            // Update the booking in the repository
            var repo = new Bookingsrepository();
            repo.UpdateBooking(_currentBooking);

            // Close the form and return an OK result to the calling form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadServicesDropdown()
        {
            var servicesRepo = new Servicesrepository();
            var services = servicesRepo.GetServices(); // Get all services from the repository

            if (services == null || services.Count == 0)
            {
                MessageBox.Show(ALEXISMessages.Noservicesdatabase, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add a placeholder item to indicate no selection
            var placeholder = new Service { ServiceID = 0, ServiceName = "Select a Service" };
            services.Insert(0, placeholder); // Insert the placeholder at the top of the list

            servicecmb.DataSource = services;
            servicecmb.DisplayMember = "ServiceName"; // Display the service name in the ComboBox
            servicecmb.ValueMember = "ServiceID";    // Store the ServiceID in the value of ComboBox

            // Set the default selected item to the placeholder
            servicecmb.SelectedIndex = 0;    // Store the ServiceID in the value of ComboBox
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Get selected service from ComboBox (which holds a Service object)
            var selectedServiceID = (int)servicecmb.SelectedValue;

            // Fetch the selected service using the selected ID
            var selectedService = new Servicesrepository().GetService(selectedServiceID);

            if (selectedService != null)
            {
                int hours = (int)numberofhoursnum.Value; // Get the number of hours from the numeric updown

                if (hours > 8)
                {
                    MessageBox.Show(ALEXISMessages.ServiceHourserr);
                    return;
                }

                // Create a new ServiceDetail object using the selected service's details
                var serviceDetails = new ServiceDetail
                {
                    ServiceID = selectedService.ServiceID,  // Use ServiceID from the Service object
                    ServiceName = selectedService.ServiceName,
                    Rate = selectedService.HourlyRate,
                    Hours = hours,  // Ensure that Hours is set here
                    TotalAmount = selectedService.HourlyRate * hours
                };

                // Add the service to the booking
                _currentBooking.AddService(serviceDetails);

                // Reload the services in the grid
                LoadServicesToGrid();

                // Update the total amount
                totalamounttb.Text = _currentBooking.TotalAmount.ToString("F2");

                MessageBox.Show(ALEXISMessages.Serviceaddsucc);
            }
            else
            {
                MessageBox.Show(ALEXISMessages.Serviceaddnotfound);
            }
        }
        private void LoadServicesToGrid()
        {
            if (_currentBooking == null || _currentBooking.ServiceDetails == null)
            {
                MessageBox.Show(ALEXISMessages.Serviceaddnoadd);
                return;
            }

            servicesdatagrid.AutoGenerateColumns = false; // Prevent auto column generation
            servicesdatagrid.DataSource = null;
            servicesdatagrid.DataSource = _currentBooking.ServiceDetails;

            // Reconfigure columns
            ConfigureGridColumns();
        }

        // In the form's designer or in the Load event, you can manually configure the columns.
        private void ConfigureGridColumns()
        {
            servicesdatagrid.Columns.Clear(); // Clear any existing columns

            servicesdatagrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ServiceID",
                HeaderText = "Service ID",
                DataPropertyName = "ServiceID", // Matches property name in ServiceDetail
                Visible = false // Optional
            });

            servicesdatagrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ServiceName",
                HeaderText = "Service Name",
                DataPropertyName = "ServiceName"
            });

            servicesdatagrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rate",
                HeaderText = "Hourly Rate",
                DataPropertyName = "Rate"
            });

            servicesdatagrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Hours",
                HeaderText = "Hours",
                DataPropertyName = "Hours"
            });

            servicesdatagrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Total Amount",
                DataPropertyName = "TotalAmount"
            });
        }
        private void bookingsave_Click(object sender, EventArgs e)
        {
            // Update booking details
            _currentBooking.ClientName = clienttb.Text;
            _currentBooking.BookingDate = bookingtb.Value;

            // Total amount is already updated dynamically when services are added/removed
            _currentBooking.TotalAmount = _currentBooking.ServiceDetails.Sum(sd => sd.TotalAmount);

            // Save the updated booking
            var repo = new Bookingsrepository();
            repo.UpdateBooking(_currentBooking);

            MessageBox.Show(ALEXISMessages.Bookingupdatesuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Bookingdetailscancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void servicecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure the ComboBox has a selected item
            if (servicecmb.SelectedIndex >= 0) // Check that an item is selected
            {
                if (servicecmb.SelectedItem is Service selectedService)
                {
                    // Update the HourlyRatetb with the selected service's hourly rate
                    HourlyRatetb.Text = selectedService.HourlyRate.ToString("C"); // Format as currency
                }
            }
            else
            {
                Console.WriteLine("No valid service selected.");
            }
        }



    }
}
 