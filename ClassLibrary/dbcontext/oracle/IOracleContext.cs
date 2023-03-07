using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ModelClassLibrary.connection
{
    public interface IOracleContext
    {
        IDbConnection GetConnection();
    }
}
