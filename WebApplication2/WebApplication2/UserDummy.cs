using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public class UserDummy
    {
        public int getUserID()
        {
            String query = "SELECT [CustomerID] FROM [team_project475].[customer] where [CustomerID]=1";
            DBConnection dbCon = new DBConnection();
            SqlConnection conn = dbCon.connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);



            var user = (Int64)command.ExecuteScalar();

            return (int)user;
     
    }
        
    }
}