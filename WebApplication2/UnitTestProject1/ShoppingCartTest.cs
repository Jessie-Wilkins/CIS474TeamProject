using Microsoft.VisualStudio.TestTools.UnitTesting; //Library for unit testing
using WebApplication2; //Imports web application project

namespace UnitTestProject1
{
    /*
     Class for testing the shopping cart class
     */
    [TestClass]
    public class ShoppingCartTest
    {
        /*
         Tests wheter the items are added to the cart.
         */
        [TestMethod]
        public void AddToCartTest()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddToCart("TestItem");

            var items = cart.getItems();
            //Tests if the item is added to the cart. If it was, the test passes.
            Assert.AreEqual(items[1], "TestItem");
        }
        /*
         Tests whether item has been removed from the cart.
         */
        [TestMethod]
        public void RemoveFromCartTest()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddToCart("TestItem");

            cart.RemoveFromCart(1);

            var items = cart.getItems();
            //If item that was added has been removed, the test passes.
            Assert.IsFalse(items.ContainsKey(1));
        }
        /*
         Tests whether the options were altered for the given item
         */
        [TestMethod]
        public void AlterOptionsTest()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AlterOptions(1,"TestOption");

            var options = cart.getOptions();
            // If the options equals the given string, then the test passes.
            Assert.AreEqual(options[1], "TestOption");
        }

    }
}
