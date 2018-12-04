using System;//Library for using system related classes and methods

namespace WebApplication2
{
    /*
     Class used to give message that transaction is complete.
     Can go back to menu or log out.
     */
    public partial class TransactionComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Div2.InnerHtml = String.Format("Your order will be ready in {0}", Session["ETA"].ToString());
        }
    }
}