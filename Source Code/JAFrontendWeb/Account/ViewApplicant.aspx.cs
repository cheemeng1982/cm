using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace JAFrontendWeb.Account
{
    public partial class ViewApplicant : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        new void Page_Load(object sender, EventArgs e)
        {
            //Add stylesheet reference to base master
            Master.StyleSheets.Add("page_AccountCreation.css");

            if (!Page.IsPostBack)
            {

            }
        }
    }
}
