using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class SQLEnterLogIn
    {
        private string query;

        private void SetQuery(string value)
        {
            query = value;

        }

        public string GetQuery()
        {
            return query;
        }

        public SqlDataReader EnterInfo(string name, string password)
        {
            SetQuery(String.Format("INSERT INTO [team_project475].[customer](username, password) VALUES('{0}','{1}')", name, password));
            DBConnection dbCon = new DBConnection();
            SqlConnection conn = dbCon.connect();
            conn.Open();

            SqlCommand command = new SqlCommand(GetQuery(), conn);

            return command.ExecuteReader();

        }

    }
}
