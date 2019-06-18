using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repertoire.Models
{
    public class ContactModel
    {
        public int id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
