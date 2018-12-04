using WebApplication2; //Imports web application project
using Microsoft.VisualStudio.TestTools.UnitTesting; //Library for unit testing
using System.Data.SqlClient; //Library used to connect and query sql database

namespace UnitTestProject1
{
    /*
     Tests if transaction page does complete the transaction
     */
    [TestClass]
    public class TransactionTest : Transaction
    {
        /*
         Tests if the transaction was recorded by the database.
         */
        [TestMethod]
        public void CompleteTransaction_Test()
        {
            string items_string = "item";
            string options_string = "options";
            decimal totalPrice = 23.00M;
            int userID = 1;


            SqlDataReader reader = CompleteTransaction_Code(items_string, options_string, totalPrice, userID);

            reader.Read();
            //Sees if the number of rows entered in is 1. If it is, it passes.
            Assert.AreEqual(reader.RecordsAffected, 1);
        }
    }
}
