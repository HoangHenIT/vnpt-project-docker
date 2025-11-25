using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.dbcontext.connect
{
    public class ConnectionStringImpl
    {
        public static string defaultconnectionSQLServer = "data source=HENTVH;initial catalog=vnptauth;user id=sa;password=123456aA@;MultipleActiveResultSets=True;Encrypt=True;Connection Timeout=60;TrustServerCertificate=True;";
        public static string defaultconnectionSQLServerProduct = "data source=HENTVH;initial catalog=products;user id=sa;password=123456aA@;MultipleActiveResultSets=True;Encrypt=True;Connection Timeout=60;TrustServerCertificate=True;";

    }
}
