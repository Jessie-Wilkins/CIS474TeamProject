using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class TransactionComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Div2.InnerHtml = String.Format("Your order will be ready in {0}", Session["ETA"].ToString());
        }
    }
}