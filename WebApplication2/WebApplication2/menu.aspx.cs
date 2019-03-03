using System; //Adds system classes to the code
using System.Web.UI.WebControls; //Adds UI controls for menu

namespace WebApplication2
{
    /*
     Class is used to create an online menu with food items to select and customizations and gives pricing
     */
    public partial class menu : System.Web.UI.Page
    {
        /*
         Method that performs operations when the page is loaded
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            //Creates the objects for the session variables containing the shopping cart object and the price total
            object cartObj = Session["Cart"];
            object totalObj = Session["Total"];
            //Goes into code if the page is being posted back
            if (!this.IsPostBack)
            {
                //Goes into the code for the page loading
                Page_Load_Code(cartObj, totalObj);
               
            }

        }
        /*
         Method either loads a new shopping cart object and binds it to the repeater if it has never seen these before,
         or it loads up a already used shopping cart object if we are seeing this page again in this session
         */
        protected void Page_Load_Code(object cartObj, object totalObj )
        {
            if (cartObj == null && totalObj == null)
            {
                ShoppingCart cart = new ShoppingCart();
                Repeater1.DataSource = cart.getItems();
                Repeater1.DataBind();
                ViewState["cart"] = cart;

            }
            else
            {
                ShoppingCart cart = cartObj as ShoppingCart;
                Repeater1.DataSource = cart.getItems();
                Repeater1.DataBind();
                ViewState["cart"] = cart;
                //Adds the total prices to the text
                Label2.Text = totalObj.ToString();

            }
        }
        /*
         Adds item to the menu when the food is selected and updates the price of the order
         */
        protected void Add_Item(object sender, CommandEventArgs e)
        {
           
            var myString = e.CommandArgument.ToString();
            Add_Item_Code(myString);
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;
            Repeater1.DataSource = cart.getItems();
            Repeater1.DataBind();
            //Splits string on dollar sign to just get value
            string[] cost = myString.Split('$');

            double Total_cost = double.Parse(Label2.Text);
            //Gets the number part of the string and parses it
            Total_cost = double.Parse(cost[1]) + Total_cost;
            Label2.Text = Total_cost.ToString();
        }
        /*
         Code used to modularize part of the add_item method for testing purposes
         */
        protected string Add_Item_Code(string myString)
        {
           ShoppingCart cart = ViewState["cart"] as ShoppingCart;

           cart.AddToCart(myString);

            ViewState["cart"] = cart;

            return myString;
        }
        /*
         Removes item from the menu and reduces the total price
         */
        protected void Remove_Item(object sender, CommandEventArgs e)
        {
           
            var myString = e.CommandArgument.ToString();

            //Gets bool used to determine whether the prices should be reduced or not.
            bool test_case = Remove_Item_Code(myString);

            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            Repeater1.DataSource = cart.getItems();
            Repeater1.DataBind();
            //Splits the total string on the dollar so that the number value is isolated
            string[] cost = myString.Split('$');

            decimal Total_cost = decimal.Parse(Label2.Text);
            //Takes the number part of the array and makes it part of the cost
            decimal num_cost = decimal.Parse(cost[1].Substring(0, 4));
            //If the boolean is true, then we are actually removing an item and will reduce its price.
            if (test_case)
            {


                Total_cost = Total_cost - num_cost;

                Label2.Text = Total_cost.ToString();

            }

        }
        //Code used with item code to make it modular for testing purposes
        protected bool Remove_Item_Code(string myString)
        {
            var myID = int.Parse(myString[1].ToString());

            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            bool test_case = cart.RemoveFromCart(myID);

            
            ViewState["cart"] = cart;

            return test_case;
        }
        /*
         Opens up popup window used to customize each item in the order
         */
        protected void Customize_Item(object sender, CommandEventArgs e)
        {
            
            var myString = e.CommandArgument.ToString();

            int myID = Customize_Item_Code(myString);

            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            var options = cart.getOptions();

            
            //Loops through the list of options to determine from the previous shopping cart list
            //which items should be checked or selected already and which shouldn't
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected && !options[myID].Contains(item.Value))
                {
                    CheckBoxList1.Items.FindByText(item.Value).Selected = false;
                }
                else if (!item.Selected && options[myID].Contains(item.Value))
                {
                    CheckBoxList1.Items.FindByText(item.Value).Selected = true;
                }
            }
            //Window pops up
            PopUp.Show();

        }
        /*
         Code used for the customize item method to make it modular for testing purposes
         */
        protected int Customize_Item_Code(string myString)
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            var myID = int.Parse(myString[1].ToString());

            ViewState["id_temp"] = myID;

            return myID;

        }
        /*
         Code used to respond to checked options and add them to the options lists
         */
        protected void CheckedAction(object sender, CommandEventArgs e)
        {
            ListItemCollection checkItems = CheckBoxList1.Items;
            CheckedActionCode(checkItems);
        }
        /*
          Code used for the checked action method to make it modular for testing purposes
         */
        protected void CheckedActionCode(ListItemCollection checkItems)
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            int myID = int.Parse(ViewState["id_temp"].ToString());

            string optionsSelected = "";
            //Reads through list of options and adds the option to the string
            //if it is a selected item
            foreach (ListItem item in checkItems)
            {
                if (item.Selected)
                {

                    optionsSelected = optionsSelected + item.Text + ",";
                }
            }
            cart.AlterOptions(myID, optionsSelected);
            ViewState["cart"] = cart;

        }
        /*
         Closes the popup window
         */
        protected void HideOptions(object sender, CommandEventArgs e)
        {
            PopUp.Hide();
        }

        /*
         Method used to go to the transaction/cart page
         */
        protected void GoToCart(object sender, CommandEventArgs e) {
            GoToCartCode();
        }
        /*
         Code used for the checked action method to make it modular for testing purposes
         */
        protected void GoToCartCode()
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            Session["cart"] = cart;
            Session["Total"] = Label2.Text;
            //Transfers the user to the transaction page
            // Server.Transfer("Transaction.aspx");
            Response.Clear();
            Response.Redirect("Transaction.aspx");
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            //Server.Transfer("index.aspx");
            Response.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}