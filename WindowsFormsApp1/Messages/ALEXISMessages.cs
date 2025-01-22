using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Messages
{
    public class ALEXISMessages
    {
        //Client Messages & Query
        public const string ClientDelete = "Are you sure you want to delete this Client?";
        public const string SelectClients = "SELECT * FROM Clients ORDER BY ClientID DESC";
        public const string SelectGetClients = "SELECT * FROM Clients WHERE ClientID=@ClientID";
        public const string CreateClient = "INSERT INTO Clients" +
                        "(Name, Contact, Address) VALUES " +
                        "(@Name, @Contact, @Address);";
        public const string UpdateClient = "UPDATE Clients " +
                        "SET Name=@Name, Contact=@Contact, Address=@Address " +
                        "WHERE ClientID=@ClientID";
        public const string DeleteClient= "DELETE FROM Clients WHERE ClientID=@ClientID";
        public const string Erroremptyfields = "There are empty fields. Please enter a Fill the Values.";

        //Inventory Messages & Query
        public const string NoServices = "No services found in the database.";
        public const string ToolNotempty = "Tool name cannot be empty.";
        public const string SelectValid = "Please select a valid service.";
        public const string QuantityGreater = "Quantity must be greater than zero.";
        public const string ToolAdded = "Tool added successfully.";
        public const string Selectarow = "Please select a row to delete.";
        public const string Selectarowinv = "Selected row has an invalid ToolID.";
        public const string DeleteConfirm = "Are you sure you want to delete this Tool?";
        public const string DeleteSuccess = "Tool deleted successfully.";
        public const string Selectrowupdate = "Please select a row to update.";
        public const string InvalidToolID = "Invalid Tool ID selected.";
        public const string InvalidToolname = "Tool name cannot be empty.";
        public const string ToolUpdateSuccess = "Tool updated successfully.";
        public const string GetInventories = @"
                SELECT i.ToolID, i.ToolName, s.ServiceName, i.QuantityAvailable
                FROM Inventory i
                INNER JOIN Services s ON i.ServiceID = s.ServiceID
                ORDER BY i.ToolID DESC";
        public const string GetInventory = "SELECT * FROM Inventory WHERE InventoryID=@InventoryID";
        public const string CreateTool = "INSERT INTO Inventory" +
                        "(ToolName, ServiceID, QuantityAvailable) VALUES " +
                        "(@ToolName, @ServiceID, @QuantityAvailable);";
        public const string DeleteTool = "DELETE FROM Inventory WHERE ToolID = @ToolID";
        public const string UpdateTool= "UPDATE Inventory " +
                                 "SET ToolName = @ToolName, ServiceID = @ServiceID, QuantityAvailable = @QuantityAvailable " +
                                 "WHERE ToolID = @ToolID";

        //Services Messages & Query
        public const string ErrorEmpty = "There are empty fields. Please fill in all the values.";
        public const string InvalidRate = "Invalid Hourly Rate. Please enter a valid decimal value.";
        public const string Selectedit = "Please select a row to edit.";
        public const string Servicemissing = "ServiceID is missing or invalid. Please refresh the list and try again.";
        public const string InvalidFormat = "Invalid ServiceID format. Please refresh the list and try again.";
        public const string Servicenotfound = "Service not found. Please refresh the list and try again.";
        public const string InvalidHourlyRate = "Invalid Hourly Rate. Please enter a valid decimal value.";
        public const string ServiceNameEmpty = "Service Name cannot be empty.";
        public const string UpdateSuccess = "Service updated successfully.";
        public const string SelectRow = "Please select a row to delete.";
        public const string Deleteconf = "Are you sure you want to delete this Service?";
        public const string GetServices = "SELECT * FROM Services ORDER BY ServiceID DESC";
        public const string GetService = "SELECT * FROM Services WHERE ServiceID=@ServiceID";
        public const string CreateService = "INSERT INTO Services" +
                        "(ServiceName, HourlyRate) VALUES " +
                        "(@ServiceName, @HourlyRate);";
        public const string UpdateService = "UPDATE Services " +
                                 "SET ServiceName=@ServiceName, HourlyRate=@HourlyRate " +
                                 "WHERE ServiceID=@ServiceID";
        public const string DeleteService = "DELETE FROM Services WHERE ServiceID=@ServiceID";

        //Bookings Messages & Query
        public const string SelectValidClient = "Please select a valid Client.";
        public const string ClientBooked = "This client already has a booking on the selected date. Please choose a different date.";
        public const string BookingNotFound = "Booking not found in the database.";
        public const string BookingNotValid = "Booking ID is not a valid number.";
        public const string BookingNoSelect = "No valid Booking ID found in the selected row.";
        public const string BookingNotSelect = "No booking selected. Please select a booking to edit.";
        public const string Selectrowtodelete = "Please select a row to delete.";
        public const string Deleteconfirm = "Are you sure you want to delete this Booking?";
        public const string Noclientsfound = "No clients found in the database.";
        public const string Getbookings = @"
                SELECT 
                    b.BookingID, 
                    b.ClientID, 
                    b.BookingReference, 
                    b.BookingDate, 
                    b.TotalAmount, 
                    c.Name AS ClientName
                FROM 
                    Bookings b
                JOIN 
                    Clients c ON b.ClientID = c.ClientID";
        public const string Searchbooking = @"
                SELECT 
                    b.BookingID, 
                    b.ClientID, 
                    b.BookingReference, 
                    b.BookingDate, 
                    b.TotalAmount, 
                    c.Name AS ClientName
                FROM 
                    Bookings b
                JOIN 
                    Clients c ON b.ClientID = c.ClientID
                WHERE 
                    c.Name LIKE @SearchTerm OR b.BookingReference LIKE @SearchTerm";
        public const string Getbooking = @"
                SELECT b.BookingID, b.ClientID, b.BookingDate, b.TotalAmount, c.Name AS ClientName 
                FROM Bookings b
                JOIN Clients c ON b.ClientID = c.ClientID
                WHERE b.BookingID = @BookingID";
        public const string CreateBooking = @"
                INSERT INTO Bookings (ClientID, BookingDate, TotalAmount, BookingReference) 
                VALUES (@ClientID, @BookingDate, @TotalAmount, @BookingReference);";
        public const string DeleteBooking = "DELETE FROM Bookings WHERE BookingID=@BookingID";
        public const string UpdateBooking = @"
                UPDATE Bookings 
                SET ClientID = @ClientID, BookingDate = @BookingDate, TotalAmount = @TotalAmount
                WHERE BookingID = @BookingID";
        public const string isdatebooked = @"
                            SELECT COUNT(1)
                            FROM Bookings
                            WHERE ClientID = @ClientID AND CAST(BookingDate AS DATE) = @BookingDate";

        //BookingDetails Messages & Query
        public const string Bookingnotload = "Booking details could not be loaded.";
        public const string Noservicesdatabase = "No services found in the database.";
        public const string ServiceHourserr = "Service hours cannot exceed 8 hours.";
        public const string Serviceaddsucc = "Service added to the booking!";
        public const string Serviceaddnotfound = "Service not found.";
        public const string Serviceaddnoadd = "No services available for this booking.";
        public const string Serviceselectno = "Selected service not found in the booking's service list.";
        public const string Novalidserviceselect = "No valid service selected.";
        public const string Invalidrowclicked = "Invalid row clicked, no selection.";
        public const string Bookingupdatesuccess = "Booking updated successfully!";


        //Billings Messages & Query
        public const string Billinggupdatesuccess = "Billing record updated successfully.";
        public const string Invalidnumeric = "Please enter valid numeric values for Amount Due and Amount Paid.";
        public const string Getbillings = @"
                SELECT b.BillingID, b.BookingID, b.AmountDue, b.AmountPaid, b.PaymentStatus, b.BillingReference, c.Name AS ClientName
                FROM Billings b
                INNER JOIN Bookings bo ON b.BookingID = bo.BookingID
                INNER JOIN Clients c ON bo.ClientID = c.ClientID";
        public const string InsertBilling = "INSERT INTO Billings (BookingID, AmountDue, AmountPaid, PaymentStatus, BillingReference) " +
                               "VALUES (@BookingID, @AmountDue, @AmountPaid, @PaymentStatus, @BillingReference)";
        public const string UpdateBilling = @"
            UPDATE Billings
            SET BookingID = @BookingID, AmountDue = @AmountDue, AmountPaid = @AmountPaid, PaymentStatus = @PaymentStatus
            WHERE BillingID = @BillingID";
        public const string DeleteBilling = "DELETE FROM Billings WHERE BillingID=@BillingID";
        public const string Getbillingbyid = "SELECT BillingID, BookingID, AmountDue, AmountPaid, PaymentStatus FROM Billings WHERE BookingID = @BookingID";








    }
}
