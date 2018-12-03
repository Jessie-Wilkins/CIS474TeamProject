using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2;

namespace UnitTestProject1
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void AddToCartTest()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddToCart("TestItem");

            var items = cart.getItems();

            Assert.AreEqual(items[1], "TestItem");
        }

        [TestMethod]
        public void RemoveFromCartTest()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddToCart("TestItem");

            cart.RemoveFromCart(1);

            var items = cart.getItems();

            Assert.IsFalse(items.ContainsKey(1));
        }

        [TestMethod]
        public void AlterItemsTest()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AlterOptions(1,"TestOption");

            var options = cart.getOptions();

            Assert.AreEqual(options[1], "TestOption");
        }

    }
}
