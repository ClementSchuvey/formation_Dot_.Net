using Repertoire.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repertoire
{
    public static class globalVariable
    {
        public static SqlConnection db = new SqlConnection("data source = dotnet2\\SQLEXPRESS; initial catalog = repertory; integrated security = True; multipleactiveresultsets=True; database=repertory; integrated security = SSPI;");
        public static UserModel userConnected = new UserModel();
    }
}
