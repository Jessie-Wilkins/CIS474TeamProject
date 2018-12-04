using Microsoft.VisualStudio.TestTools.UnitTesting; //Library used for unit testing
using WebApplication2; //Connects to the Web Application
using System.Web.UI.WebControls; //Used to access web controls

namespace UnitTestProject1
{
    /*
     Class used to test the menu page code
     */
    [TestClass]
    public class menuTesting : menu
    {
        /*
         Tests if the string that was added to the menu was actually added to the menu
         */
        [TestMethod]
        public void Add_Item_Test()
        {

            menuTesting item = new menuTesting();


            string myString = "test";

            item.ViewState["cart"] = new ShoppingCart();

            item.Add_Item_Code(myString);

            ShoppingCart cart = item.ViewState["cart"] as ShoppingCart;

            //Tests if the stored string item equals the string that was entered
            Assert.AreEqual(cart.getItems()[1], myString);

        }
        /*
         Tests to see if the item entered was removed
         */
        [TestMethod]
        public void Remove_Item_Test()
        {
            
            menuTesting item = new menuTesting();


            string myString = "t1est";

            item.ViewState["cart"] = new ShoppingCart();

            item.Add_Item_Code(myString);

            item.Remove_Item_Code(myString);

            ShoppingCart cart = item.ViewState["cart"] as ShoppingCart;
            //Tests if the key for the item exists anymore. The test passes if it is not.
            Assert.IsFalse(cart.getItems().ContainsKey(1));

        }
        /*
         Tests if the option does exist in the dictionary
         */
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
            //Tests if the option with the given id does exist. If it does, it passes.
            Assert.AreEqual(init_cart.getOptions()[id], "options");
        }
        /*
         Tests if the items selected are entered into the dictionary
         */
        [TestMethod]
        public void CheckedActionSelectedTest()
        {
            menuTesting item = new menuTesting();


            string myString = "t1est";

            ShoppingCart init_cart = new ShoppingCart();

            init_cart.AddToCart(myString);

            item.ViewState["cart"] = init_cart;

            item.ViewState["id_temp"] = 1;
            //Create collection mimicking check bubble menu
            ListItemCollection checkItems = new ListItemCollection();
            checkItems.Add("option1");
            checkItems.Add("option2");
            //Sets both values as selected or checked
            checkItems.FindByValue("option1").Selected = true;
            checkItems.FindByValue("option2").Selected = true;

            item.CheckedActionCode(checkItems);

            init_cart = item.ViewState["cart"] as ShoppingCart;
            //Tests if the options were added. If they were, it passes.
            Assert.AreEqual(init_cart.getOptions()[1], "option1,option2,");

            
        }
        /*
         Tests whether items not selected will not be stored in the dictionary
         */
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
            //One item will be selected, but the other will not be
            checkItems.FindByValue("option1").Selected = true;
            checkItems.FindByValue("option2").Selected = false;

            item.CheckedActionCode(checkItems);

            init_cart = item.ViewState["cart"] as ShoppingCart;
            //Tests if the items are in the dictionary. If not, the test passes.
            Assert.AreNotEqual(init_cart.getOptions()[1], "option1,option2,");


        }
    }
    
}
