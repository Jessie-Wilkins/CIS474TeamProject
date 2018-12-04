using System;
using WebApplication2;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace UnitTestProject1
{
    [TestClass]
    public class TransactionTest : Transaction
    {
        [TestMethod]
        public void CompleteTransaction_Test()
        {
            string items_string = "item";
            string options_string = "options";
            decimal totalPrice = 23.00M;
            int userID = 1;


            SqlDataReader reader = CompleteTransaction_Code(items_string, options_string, totalPrice, userID);

            reader.Read();

            Assert.AreEqual(reader.RecordsAffected, 1);
        }
    }
}
