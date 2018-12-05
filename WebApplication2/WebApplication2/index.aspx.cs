using System;
using System.Collections.Generic;
using System.Linq; //used for communicating with data sources
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //used for communicating with the sql database
using System.Data; //Used for system data related purposes

namespace online_burger_order
{
    /*
     Class used for the sign up page. New customers will enter in their information
     and be stored into the database system.
     */
    public partial class index : System.Web.UI.Page
    {
        //Connection string used to connect to the database
        string connectionString = @"Data Source = MEGAORA81; Initial Catalog = cis474TeamProject; Integrated Security = True;";
        /*
         Page is cleared when reloaded
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }
        /*
         Submits user information if button is clicked.
         */
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                lblErrorMessage.Text = "Please enter the mandatory fields represented by '*' mark.";
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblErrorMessage.Text = "Password and confirm Password doen't match!!!";
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM [team_project475].[customer] WHERE username =@UserName";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    //Gets the count of the rows
                    int count = Convert.ToInt32(sqlCmd2.ExecuteScalar());
                    //If number of rows is greater than 0, then this means that there is already a customer logged in with the is username
                    if (count > 0)
                    {
                        // the user name already exist.
                        //Ask user to enter another user name.
                        lbluserNameExist.Text = "This User Name already exist, please try having another User Name!!!";
                    }
                    //If the number of rows is 0, then add the information to the database
                    else
                    {
                        //Initiates data entry procedure
                        SqlCommand sqlCmd = new SqlCommand("UserAddorEdit", sqlCon);

                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        //Adds all the given data from the text fields
                        sqlCmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                        sqlCmd.Parameters.AddWithValue("@CustomerName", txtLastName.Text.Trim() + ","+txtFirstName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt64(txtContact.Text.Trim()));
                        sqlCmd.Parameters.AddWithValue("@CreditCardNumber", Convert.ToInt64(txtCreditCard.Text.Trim()));
                        sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                        //Executes the queries
                        sqlCmd.ExecuteNonQuery();
                        //Clears the screen when executed
                        Clear();
                        lblSuccessMessage.Text = "Submitted Sucessfully";
                    }
                }
            }
          
        }
        /*
         Method used to clear all text fields
         */
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUserName.Text = txtPassword.Text = txtConfirmPassword.Text = "";
            hfUserID.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }
        /*
         Redirects user to login screen
         */
        protected void btn_go_login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}