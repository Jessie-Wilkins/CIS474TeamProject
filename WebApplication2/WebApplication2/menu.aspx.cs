﻿using AjaxControlToolkit.HtmlEditor;
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
            if (!this.IsPostBack)
            {
                Page_Load_Code();
               
            }

        }

        protected void Page_Load_Code()
        {
            if (Session["Cart"] == null && Session["Total"] == null)
            {
                ShoppingCart cart = new ShoppingCart();
                Repeater1.DataSource = cart.getItems();
                Repeater1.DataBind();
                ViewState["cart"] = cart;

            }
            else
            {
                ShoppingCart cart = Session["Cart"] as ShoppingCart;
                Repeater1.DataSource = cart.getItems();
                Repeater1.DataBind();
                ViewState["cart"] = cart;
                Label2.Text = Session["Total"].ToString();

            }
        }

        protected void Add_Item(object sender, CommandEventArgs e)
        {

            var myString = e.CommandArgument.ToString();
            Add_Item_Code(myString);
            

        }

        protected void Add_Item_Code(string myString)
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            cart.AddToCart(myString);

            Repeater1.DataSource = cart.getItems();
            Repeater1.DataBind();

            string[] cost = myString.Split('$');

            double Total_cost = double.Parse(Label2.Text);

            Total_cost = double.Parse(cost[1]) + Total_cost;

            Label2.Text = Total_cost.ToString();

            ViewState["cart"] = cart;
        }

            protected void Remove_Item(object sender, CommandEventArgs e)
            {

            var myString = e.CommandArgument.ToString();

            var myID = int.Parse(myString[1].ToString());

            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            bool test_case = cart.RemoveFromCart(myID);

            Repeater1.DataSource = cart.getItems();
            Repeater1.DataBind();

            string[] cost = myString.Split('$');
            
            decimal Total_cost = decimal.Parse(Label2.Text);
            decimal num_cost = decimal.Parse(cost[1].Substring(0, 4));
            if (test_case)
            {
                //string specifier = "R";
                //var culture = CultureInfo.CreateSpecificCulture("en-US");

                Total_cost = Total_cost - num_cost;

                Label2.Text = Total_cost.ToString();

            }
            ViewState["cart"] = cart;
           
   
        }

        protected void Remove_Item_Code()
        {

        }

        protected void Customize_Item(object sender, CommandEventArgs e)
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            var myString = e.CommandArgument.ToString();

            var myID = int.Parse(myString[1].ToString());

            ViewState["id_temp"] = myID;

            var options = cart.getOptions();

            foreach (ListItem item in CheckBoxList1.Items)
            {
                if(item.Selected && !options[myID].Contains(item.Value))
                {
                    CheckBoxList1.Items.FindByText(item.Value).Selected = false;
                }
                else if(!item.Selected && options[myID].Contains(item.Value))
                {
                    CheckBoxList1.Items.FindByText(item.Value).Selected = true;
                }
            }

            PopUp.Show();

            

        }

        protected void CheckedAction(object sender, CommandEventArgs e)
        {
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            int myID = int.Parse(ViewState["id_temp"].ToString());

            string optionsSelected = " ";

            foreach (ListItem item in CheckBoxList1.Items)
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
            ShoppingCart cart = ViewState["cart"] as ShoppingCart;

            UserDummy userDummy = new UserDummy();

            Session["cart"] = cart;
            Session["Total"] = Label2.Text;

            Server.Transfer("Transaction.aspx");
        }

        

    }
}