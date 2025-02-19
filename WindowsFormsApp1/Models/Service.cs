﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal HourlyRate { get; set; }

        // Override ToString to control what is shown in the ComboBox
        public override string ToString()
        {
            return $"{ServiceName} ({HourlyRate:C})"; // Customize the format as needed
        }

    }
}
