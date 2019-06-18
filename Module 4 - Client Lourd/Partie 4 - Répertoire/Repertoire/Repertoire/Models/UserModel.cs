using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repertoire.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
    }
}
