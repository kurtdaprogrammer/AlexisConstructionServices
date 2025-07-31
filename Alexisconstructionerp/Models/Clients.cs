using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexisconstructionerp.Models
{
  public interface IClients
  {
        int Client_id { get; set; }
        string Client_Name { get; set; }
        string Client_Address { get; set; }
        string Client_Phoneno { get; set; }
        string Client_Email { get; set; }
    } 
}
