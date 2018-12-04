using Microsoft.VisualStudio.TestTools.UnitTesting; //Library for unit testing
using WebApplication2; //Imports web application project
using System.Data.SqlClient; //Library used to connect and query sql database

namespace UnitTestProject1
{

    /*
     Class for testing SQL connection
     */
    [TestClass]
    public class TestSQLConnection
    {
        //Used to write test results
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        /*
         Tests whether the database can connect
         */
        [TestMethod]
        public void TestDBConnection()
        {
            DBConnection dbTest = new DBConnection();
            //If the connection object is not null, it passes.
            Assert.IsNotNull(dbTest.connect());
            //Write test results
            TestContext.WriteLine("Test for SQL connection function.");
        }
        

    }
}
