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
using JAFrontendWeb.Account;

namespace JAFrontendWeb.controls
{
    public partial class UserNavigation : System.Web.UI.UserControl
    {
        BasePage basePage = new BasePage();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            linkHome.Visible = !(Page is Index);
            linkCreateApplicant.Visible = !(Page is Account.ApplicantCreation);
            linkViewApplicant.Visible = !(Page is Account.ViewApplicant);
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx");
        }

        protected void Edit(object sender, CommandEventArgs e)
        {
            switch (e.CommandArgument.ToString())
            {
                case "backHome":
                    Response.Redirect("../Index.aspx");
                    break;
                case "applicantCreation":
                    Response.Redirect("/Account/ApplicantCreation.aspx");
                    break;
                case "viewApplicant":
                    Response.Redirect("/Account/ViewApplicant.aspx");
                    break;
            }          
        }
    }
}