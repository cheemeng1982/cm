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
using System.Collections.Generic;
//using JAFrontendWeb.BookSellerWebServiceProvider;

namespace JAFrontendWeb.MasterPages
{
    public partial class Base : System.Web.UI.MasterPage
    {
        private const string VS_CUSTOMER_NAME = "CustomerName";

        public List<string> StyleSheets = new List<string>();
        BasePage page = new BasePage();

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string styleSheet in StyleSheets)
            {
                HtmlLink newStyleSheet = new HtmlLink();
                newStyleSheet.Href = "../Stylesheets/" + styleSheet;
                newStyleSheet.Attributes.Add("type", "text/css");
                newStyleSheet.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(newStyleSheet);
            }

            lblTodayDate.Text = DateTime.Today.ToShortDateString() + ", " + DateTime.Today.DayOfWeek;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (page.IsAuthenticated)
            {
                panelLogout.Visible = page.IsAuthenticated;
                lblWelcome.Text = "Welcome back " + GetCustomerName();
            }
        }

        private string GetCustomerName()
        {
            string customerName = string.Empty;
            //if (ViewState[VS_CUSTOMER_NAME] == null || ViewState[VS_CUSTOMER_NAME].ToString() == "")
            ////if(true)
            //{
            //    BookSellerWebService bookSellerWebService = new BookSellerWebService();
            //    Customer cus = bookSellerWebService.GetCustomerByCustomerID(page.CustomerID);

            //    if (cus != null)
            //    {
            //        customerName = cus.FirstName + " " + cus.LastName;
            //        ViewState[VS_CUSTOMER_NAME] = customerName;
            //    }
            //}
            //else
            //    customerName = ViewState[VS_CUSTOMER_NAME].ToString();

            return customerName;

        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            //BookSellerWebService bookSellerWebService = new BookSellerWebService();
            //bookSellerWebService.AuthenticateUserLogout(page.CustomerID);

            ////Clear the cookie
            //page.LogoutClearCookie();
            //ViewState[VS_CUSTOMER_NAME] = null;

            //Response.Redirect("/Login.aspx");
        }
    }
}
