using System.Data.SqlClient; //Used to accomplish SQL connections and queries

namespace WebApplication2
{
    /*
    This class is used to connect to the microsoft sql server  
    */
    public class DBConnection
    {
        /*
        Function connects to the database in order for the website to communicate with the database 
        */
        public SqlConnection connect()
        {
            //Create string and SQL connection objects
            string connectionString;
            SqlConnection connection;
            //Creates connection string
            connectionString = @"Data Source = MEGAORA81; Initial Catalog = cis474TeamProject; Integrated Security = True";
            //Creates connection object used to connect to the database later
            connection = new SqlConnection(connectionString);
            //Returns connection object
            return connection;
        }
    }
}