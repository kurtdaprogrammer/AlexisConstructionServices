using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexisERP.Models
{
    public interface IClient
    {
        int Person_id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
    }
}
