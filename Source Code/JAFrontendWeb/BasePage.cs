using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
//using JAFrontendWeb.BookSellerWebServiceProvider;

namespace JAFrontendWeb
{
    public class BasePage : System.Web.UI.Page
    {
        #region Constants
        const string COOKIE_KEY_AUTH_PUBLIC_KEY = "CookieAuthPublicKey";
        const string COOKIE_KEY_CUSTOMER_ID = "CookieCustomerID";
        #endregion

        #region Variables
        private int _customerID = 0;
        private string _authPublicKey = string.Empty;
        #endregion

        private bool _isAuthenticated = false;

        public bool IsAuthenticated
        {
            get
            {
                if (HttpContext.Current.User != null)
                {
                    _isAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;
                }
                return _isAuthenticated;
            }
        }

        public int CustomerID
        {
            get
            {
                int.TryParse(GetCookieValue(COOKIE_KEY_CUSTOMER_ID), out _customerID);
                return _customerID;
            }
            set
            {
                _customerID = value;
                SetCookie(COOKIE_KEY_CUSTOMER_ID, _customerID.ToString());
            }
        }

        public string AuthPublicKey
        {
            get
            {
                return Server.UrlDecode(GetCookieValue(COOKIE_KEY_AUTH_PUBLIC_KEY));
            }
            set
            {
                _authPublicKey = value;
                SetCookie(COOKIE_KEY_AUTH_PUBLIC_KEY, Server.UrlEncode(_authPublicKey));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClearCookieValue(COOKIE_KEY_CUSTOMER_ID);
                ClearCookieValue(COOKIE_KEY_AUTH_PUBLIC_KEY);
            }
        }

        #region Methods
        public void SetCookie(string key, string value)
        {
            HttpCookie cookie = new HttpCookie(key);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.SetCookie(cookie);
        }

        public string GetCookieValue(string key)
        {
            string returnValue = String.Empty;
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                returnValue = HttpContext.Current.Request.Cookies[key].Value;
            }
            return returnValue;
        }

        public void ClearCookieValue(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                HttpContext.Current.Request.Cookies[key].Value = "";
            }
        }

        public void LogoutClearCookie()
        {
            ClearCookieValue(COOKIE_KEY_AUTH_PUBLIC_KEY);
            ClearCookieValue(COOKIE_KEY_CUSTOMER_ID);
        }

        #endregion

    }
}
