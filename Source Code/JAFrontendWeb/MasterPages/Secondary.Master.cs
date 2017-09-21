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

namespace JAFrontendWeb.MasterPages
{
    public partial class Secondary : System.Web.UI.MasterPage
    {
        public List<string> StyleSheets = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.StyleSheets.Add("master_secondary.css");
            foreach (string styleSheet in StyleSheets)
            {
                Master.StyleSheets.Add(styleSheet);
            }
        }
    }
}

