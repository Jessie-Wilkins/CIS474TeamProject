﻿using System; //Use library with system related functions
using System.Data.SqlClient; //Use library for connecting and querying database

namespace online_burger_order
{
    /*
     Class used to login existing user
     */
    public partial class Login : System.Web.UI.Page
    {
        /*
         Loads page and makes error messages hidden
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }
        /*
         Logins the user and redirects them to the menu
         */
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Use data source
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = MEGAORA81; Initial Catalog = cis474TeamProject; Integrated Security = True;"))
            {
                sqlCon.Open();
                string query = "SELECT CustomerID FROM [team_project475].[customer] WHERE username =@UserName AND username=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //Adds value to query parameters
                sqlCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                int id;
                object sqlObject = sqlCmd.ExecuteScalar();
                //If the user does indeed exist in the sytem, redirect the user to the menu page and keep their id in a session variable
                if (sqlObject != null)
                {
                    id = Convert.ToInt32(sqlObject);
                    Session["userid"] = id;
                    Response.Redirect("menu.aspx");
                }
                //Shows error message if user does not exist in database
                else { lblErrorMessage.Visible = true; }
            }
        }

        protected void btngoback_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("index.aspx");
        }
    }
}