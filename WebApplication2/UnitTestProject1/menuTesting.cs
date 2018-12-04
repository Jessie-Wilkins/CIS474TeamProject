using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2;
using System.Web.UI.WebControls;

namespace UnitTestProject1
{
    [TestClass]
    public class menuTesting : menu
    {
        [TestMethod]
        public void Add_Item_Test()
        {

            menuTesting item = new menuTesting();


            string myString = "test";

            item.ViewState["cart"] = new ShoppingCart();

            item.Add_Item_Code(myString);

            ShoppingCart cart = item.ViewState["cart"] as ShoppingCart;


            Assert.AreEqual(cart.getItems()[1], myString);

        }

        [TestMethod]
        public void Remove_Item_Test()
        {
            menuTesting item = new menuTesting();


            string myString = "t1est";

            item.ViewState["cart"] = new ShoppingCart();

            item.Add_Item_Code(myString);

            item.Remove_Item_Code(myString);

            ShoppingCart cart = item.ViewState["cart"] as ShoppingCart;

            Assert.IsFalse(cart.getItems().ContainsKey(1));

        }
        [TestMethod]
        public void Customize_Item_Test(){
            menuTesting item = new menuTesting();


            string myString = "t1est";
            string alterString = "options";

            ShoppingCart init_cart = new ShoppingCart();

            init_cart.AddToCart(myString);

            init_cart.AlterOptions(1, alterString);

            item.ViewState["cart"] = init_cart;

            int id = item.Customize_Item_Code(myString);

            Assert.AreEqual(init_cart.getOptions()[1], "options");
        }

        [TestMethod]
        public void CheckedActionSelectedTest()
        {
            menuTesting item = new menuTesting();


            string myString = "t1est";

            ShoppingCart init_cart = new ShoppingCart();

            init_cart.AddToCart(myString);

            item.ViewState["cart"] = init_cart;

            item.ViewState["id_temp"] = 1;

            ListItemCollection checkItems = new ListItemCollection();
            checkItems.Add("option1");
            checkItems.Add("option2");
            checkItems.FindByValue("option1").Selected = true;
            checkItems.FindByValue("option2").Selected = true;

            item.CheckedActionCode(checkItems);

            init_cart = item.ViewState["cart"] as ShoppingCart;

            Assert.AreEqual(init_cart.getOptions()[1], "option1,option2,");

            
        }

        [TestMethod]
        public void CheckedActionNotSelectedTest()
        {
            menuTesting item = new menuTesting();


            string myString = "t1est";

            ShoppingCart init_cart = new ShoppingCart();

            init_cart.AddToCart(myString);

            item.ViewState["cart"] = init_cart;

            item.ViewState["id_temp"] = 1;

            ListItemCollection checkItems = new ListItemCollection();
            checkItems.Add("option1");
            checkItems.Add("option2");
            checkItems.FindByValue("option1").Selected = true;
            checkItems.FindByValue("option2").Selected = false;

            item.CheckedActionCode(checkItems);

            init_cart = item.ViewState["cart"] as ShoppingCart;

            Assert.AreNotEqual(init_cart.getOptions()[1], "option1,option2,");


        }
    }
    
}
