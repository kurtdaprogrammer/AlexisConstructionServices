using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace create_edit_client.Models
{
    public class Client : ClientString
    {
        public int Client_Id { get; set; }
        public String Client_fname { get; set; }
        public String Client_lname { get; set; }
        public String Client_Address { get; set; }
        public String Client_Phoneno { get; set; }
        public String Client_Email { get; set; }
    }
    public interface ClientString
    {
        public int Client_Id { get; set; }
        public String Client_fname { get; set; }
        public String Client_lname { get; set;}
        public String Client_Address { get; set; }
        public String Client_Phoneno { get; set; }
        public String Client_Email { get; set; }


}
