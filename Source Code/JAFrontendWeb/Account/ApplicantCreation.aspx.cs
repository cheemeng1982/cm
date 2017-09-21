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
using Newtonsoft.Json;

namespace JAFrontendWeb.Account
{
    public partial class ApplicantCreation : BasePage
    {
        com.jabackendservice.JAService JAService = new com.jabackendservice.JAService();
      
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add stylesheet reference to base master
            Master.StyleSheets.Add("page_AccountCreation.css");
            lblNotice.Text = "";
            
            if (! Page.IsPostBack)
            {
                
            }
        }

        protected void OnApplicant_Create(object sender, ApplicantEventArgs e)
        {
            string message;
            int newCustomerID = JAService.AddApplicant(Newtonsoft.Json.JsonConvert.SerializeObject(e.Applicant), out message);

            if (newCustomerID > 0)
                lblNotice.Text = "<span style='color:green;font-weight:bold;'>" + message + "</span>";
            else
                lblNotice.Text = message;
        }

    }

    public class ApplicantEventArgs : EventArgs
    {
        private com.jabackendservice.ApplicantDto _applicant;
        private bool _isCreateNew;

        public com.jabackendservice.ApplicantDto Applicant
        {
            get { return _applicant; }
            set { _applicant = value; }
        }

        public bool IsCreateNew
        {
            get { return _isCreateNew; }
            set { _isCreateNew = value; }
        }

        public ApplicantEventArgs(com.jabackendservice.ApplicantDto applicant, bool isCreateNew)
        {
            this.Applicant = applicant;
            this.IsCreateNew = isCreateNew;
        }
    }

}
