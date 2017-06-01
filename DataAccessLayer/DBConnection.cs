using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class DBConnection
    {
        public static SqlConnection GetDBConnection()
        {
            var connString = @"Data Source=localhost;Initial Catalog=gardenDatabase;Integrated Security=True";
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}
