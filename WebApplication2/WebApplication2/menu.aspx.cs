using AjaxControlToolkit.HtmlEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Collections.Specialized;

namespace WebApplication2
{
    public partial class menu : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

           
            object cartObj = Session["Cart"];
            
                
            object totalObj = Session["Total"];

            if (!this.IsPostBack)
            {
                Page_Load_Code(cartObj, totalObj);
               
            }

        }

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
                Label2.Text = totalObj.ToString();

            }
        }

        protected void Add_Item(object sender, CommandEventArgs e)
        {

            var myString = e.CommandArgument.ToString();
            Add_Item_Code(myString);
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;
            Repeater1.DataSource = cart.getItems();
            Repeater1.DataBind();

            string[] cost = myString.Split('$');

            double Total_cost = double.Parse(Label2.Text);

            Total_cost = double.Parse(cost[1]) + Total_cost;
        }

        protected string Add_Item_Code(string myString)
        {
           ShoppingCart cart = ViewState["cart"] as ShoppingCart;

           cart.AddToCart(myString);

            ViewState["cart"] = cart;

            return myString;
        }

        protected void Remove_Item(object sender, CommandEventArgs e)
        {

            var myString = e.CommandArgument.ToString();


            bool test_case = Remove_Item_Code(myString);

            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            Repeater1.DataSource = cart.getItems();
            Repeater1.DataBind();

            string[] cost = myString.Split('$');

            decimal Total_cost = decimal.Parse(Label2.Text);
            decimal num_cost = decimal.Parse(cost[1].Substring(0, 4));
            if (test_case)
            {


                Total_cost = Total_cost - num_cost;

                Label2.Text = Total_cost.ToString();

            }



        }

        protected bool Remove_Item_Code(string myString)
        {
            var myID = int.Parse(myString[1].ToString());

            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            bool test_case = cart.RemoveFromCart(myID);

            
            ViewState["cart"] = cart;

            return test_case;
        }

        protected void Customize_Item(object sender, CommandEventArgs e)
        {

            var myString = e.CommandArgument.ToString();

            int myID = Customize_Item_Code(myString);

            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            var options = cart.getOptions();

            

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

            PopUp.Show();

        }

        protected int Customize_Item_Code(string myString)
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            var myID = int.Parse(myString[1].ToString());

            ViewState["id_temp"] = myID;

            return myID;

        }

        protected void CheckedAction(object sender, CommandEventArgs e)
        {
            ListItemCollection checkItems = CheckBoxList1.Items;
            CheckedActionCode(checkItems);
        }

        protected void CheckedActionCode(ListItemCollection checkItems)
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            int myID = int.Parse(ViewState["id_temp"].ToString());

            string optionsSelected = "";

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

        protected void HideOptions(object sender, CommandEventArgs e)
        {
            PopUp.Hide();
        }


        protected void GoToCart(object sender, CommandEventArgs e) {
            GoToCartCode();
        }

        protected void GoToCartCode()
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            Session["cart"] = cart;
            Session["Total"] = Label2.Text;

            Server.Transfer("Transaction.aspx");
        }

    }
}