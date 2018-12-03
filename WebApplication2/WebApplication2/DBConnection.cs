using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class DBConnection
    {
        public SqlConnection connect()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source = MEGAORA81; Initial Catalog = cis474TeamProject; Integrated Security = True";

            connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}