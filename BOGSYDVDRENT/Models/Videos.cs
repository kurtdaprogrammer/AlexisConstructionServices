using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOGSYDVDRENT.Models
{
    public interface IVideos
    {
        int VideoID { get; set; }
        string Title { get; set; }
        string Category { get; set; }
        decimal RentalRate { get; set; }
        int MaxRentalDays { get; set; } 
        int TotalQuantity { get; set; }
    }
}
