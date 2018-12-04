using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace WebApplication2
{
    public partial class Transaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                ShoppingCart cart = Session["cart"] as ShoppingCart;
                int userID = int.Parse(Session["userID"].ToString());
                String TotalCost = Session["Total"].ToString();

                GridView1.DataSource = cart.getItems();
                GridView1.DataBind();
                GridView2.DataSource = cart.getOptions();
                GridView2.DataBind();
                Label1.Text = TotalCost;

            }
        }

        public void CompleteTransaction(object sender, EventArgs e)
        {
            ShoppingCart cart = Session["cart"] as ShoppingCart;
            int userID = int.Parse(Session["userID"].ToString());

            Dictionary<int, string> select_items = cart.getItems();
            Dictionary<int, string> select_options = cart.getOptions();
            var items_string = string.Join(";", select_items);
            var options_string = string.Join(";", select_options);
            var totalPrice = decimal.Parse(Label1.Text);

            CompleteTransaction_Code(items_string, options_string, totalPrice, userID);

            Session["ETA"] = "00:23:00";

            Server.Transfer("TransactionComplete.aspx");

        }

        public SqlDataReader CompleteTransaction_Code(string items_string, string options_string, decimal totalPrice, int userID)
        {
            String query = String.Format("INSERT INTO [team_project475].[orders](TotalPrice, OptionsSelected, ETA, CustomerID, DateOfPurchase, ItemsSelected) VALUES({0},'{1}', '{2}', {3}, '{4}', '{5}')", totalPrice, options_string, "00:23:00", userID, DateTime.Now.ToString("yyyy-MM-dd"), items_string);

            DBConnection dbCon = new DBConnection();
            SqlConnection conn = dbCon.connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void GoBack(object sender, EventArgs e)
        {
            Server.Transfer("menu.aspx");
        }
    }
}