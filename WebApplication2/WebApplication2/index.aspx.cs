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
    public partial class index : System.Web.UI.Page
    {
        string connectionString = @"Data Source = MEGAORA81; Initial Catalog = cis474TeamProject; Integrated Security = True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

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
                    int count = Convert.ToInt32(sqlCmd2.ExecuteScalar());
                    if (count > 0)
                    {
                        // the user name already exist.
                        //Ask user to enter another user name.
                        lbluserNameExist.Text = "This User Name already exist, please try having another User Name!!!";
                    }
                    else
                    {
                        SqlCommand sqlCmd = new SqlCommand("UserAddorEdit", sqlCon);

                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                        sqlCmd.Parameters.AddWithValue("@CustomerName", txtLastName.Text.Trim() + ","+txtFirstName.Text.Trim());
                        
                        sqlCmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt64(new string(txtContact.Text.Trim().Where(char.IsDigit).ToArray())));
                        sqlCmd.Parameters.AddWithValue("@CreditCardNumber", Convert.ToInt64(txtCreditCard.Text.Trim()));
                        sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                        sqlCmd.ExecuteNonQuery();

                        Clear();
                        lblSuccessMessage.Text = "Submitted Sucessfully";
                    }
                }
            }
          
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUserName.Text = txtPassword.Text = txtConfirmPassword.Text = "";
            hfUserID.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }

        protected void btn_go_login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}