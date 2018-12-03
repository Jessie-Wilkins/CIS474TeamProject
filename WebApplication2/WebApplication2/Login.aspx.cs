using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace online_burger_order
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = MEGAORA81; Initial Catalog = cis474TeamProject; Integrated Security = True;"))
            {
                sqlCon.Open();
                string query = "SELECT CustomerID FROM [team_project475].[customer] WHERE username =@UserName AND username=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                int id;
                object sqlObject = sqlCmd.ExecuteScalar();
                if (sqlObject != null)
                {
                    id = Convert.ToInt32(sqlObject);
                    Session["userid"] = id;
                    Response.Redirect("menu.aspx");
                }
                else { lblErrorMessage.Visible = true; }
            }
        }
    }
}