SELECT 
                    b.BillingID, 
                    b.BookingID, 
                    b.AmountDue, 
                    b.AmountPaid, 
                    b.PaymentStatus, 
                    b.BillingReference, 
                    c.ClientName
                FROM Billings b
                INNER JOIN Clients c ON b.BookingID = c.BookingID