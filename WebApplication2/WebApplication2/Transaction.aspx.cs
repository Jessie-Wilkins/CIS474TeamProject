using System; //Adds system classes to the code
using System.Collections.Generic; //Adds collections
using System.Data.SqlClient; //Adds ability to connect and query SQL database

namespace WebApplication2
{
    /*
     Class used for to view the final order and confirm purchase or go back to menu
     */
    public partial class Transaction : System.Web.UI.Page
    {
        /*
         Method that performs operations when the page is loaded
         */
        protected void Page_Load(object sender, EventArgs e)
        {   //Goes into code if the page is being posted back
            if (!this.IsPostBack)
            {

                ShoppingCart cart = Session["cart"] as ShoppingCart;
                int userID = int.Parse(Session["userID"].ToString());
                String TotalCost = Session["Total"].ToString();
                //Adds data to gridview
                GridView1.DataSource = cart.getItems();
                GridView1.DataBind();
                GridView2.DataSource = cart.getOptions();
                GridView2.DataBind();
                Label1.Text = TotalCost;

            }
        }
        /*
         Enters in the order into the database to complete the order
         */
        public void CompleteTransaction(object sender, EventArgs e)
        {
            
            ShoppingCart cart = Session["cart"] as ShoppingCart;
            int userID = int.Parse(Session["userID"].ToString());

            Dictionary<int, string> select_items = cart.getItems();
            Dictionary<int, string> select_options = cart.getOptions();
            //Changes the dictionaries to contiguous strings
            var items_string = string.Join(";", select_items);
            var options_string = string.Join(";", select_options);

            var totalPrice = decimal.Parse(Label1.Text);

            CompleteTransaction_Code(items_string, options_string, totalPrice, userID);

            Session["ETA"] = "00:23:00";
            //Transfers user 
            Server.Transfer("TransactionComplete.aspx");

        }
        /*
         Code used to modularize part of the complete transaction method for testing purposes.
         It returns a sql data reader in order to determine if it was successful.
         */
        public SqlDataReader CompleteTransaction_Code(string items_string, string options_string, decimal totalPrice, int userID)
        {
            String query = String.Format("INSERT INTO [team_project475].[orders](TotalPrice, OptionsSelected, ETA, CustomerID, DateOfPurchase, ItemsSelected) VALUES({0},'{1}', '{2}', {3}, '{4}', '{5}')", totalPrice, options_string, "00:23:00", userID, DateTime.Now.ToString("yyyy-MM-dd"), items_string);

            DBConnection dbCon = new DBConnection();
            SqlConnection conn = dbCon.connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);
            //Executes the query
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
        /*
         Goes back to the menu page
         */
        public void GoBack(object sender, EventArgs e)
        {
            
            Server.Transfer("menu.aspx");
        }
    }
}