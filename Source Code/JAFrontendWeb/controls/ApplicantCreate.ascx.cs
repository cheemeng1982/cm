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
using JAFrontendWeb.Account;

namespace JAFrontendWeb.controls
{
    public partial class ApplicantCreate : System.Web.UI.UserControl
    {
        com.jabackendservice.JAService JAService = new com.jabackendservice.JAService();
        //BookSellerWebService bookSellerWebService = new BookSellerWebService();
        public delegate void ApplicantEventHandler(object sender, ApplicantEventArgs e);
        public event ApplicantEventHandler SubmitApplicantCreate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Populate the country and security question into list

                ListItem item;

                var listLoc = JAService.GetLocations();
                for(int i = 0; i < listLoc.Count(); i++)
                {
                    item = new ListItem();
                    item.Text = string.Format("{0} - {1}", listLoc.ElementAt(i).LocationName, listLoc.ElementAt(i).SubLocationName);
                    item.Value = listLoc.ElementAt(i).LocationId.ToString() + "|" + listLoc.ElementAt(i).SubLocationId.ToString();

                    listLocation.Items.Add(item);
                }

                var listIndustries = JAService.GetIndustries();
                for (int i = 0; i < listIndustries.Count(); i++)
                {
                    item = new ListItem();
                    item.Text = listIndustries.ElementAt(i).IndustryName;
                    item.Value = listIndustries.ElementAt(i).IndustryId.ToString();

                    listIndustry.Items.Add(item);
                }

                var listSR = JAService.GetSalaryRanges();
                for (int i = 0; i < listSR.Count(); i++)
                {
                    item = new ListItem();
                    item.Text = listSR.ElementAt(i).Display;
                    item.Value = listSR.ElementAt(i).SalaryRangeId.ToString();

                    listSalaryRange.Items.Add(item);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                com.jabackendservice.ApplicantDto applicant = new com.jabackendservice.ApplicantDto();
                applicant.FirstName = txtboxFirstName.Text;
                applicant.LastName = txtboxLastName.Text;
                applicant.CorrespondenceAddress = txtboxAddress.Text;
                applicant.Email = txtboxEmail.Text;
                applicant.JobTitle = txtboxJobTitle.Text;
                applicant.JobSpecification = txtboxJobSpecification.Text;
                applicant.CompanyName = txtboxCompanyName.Text;
                applicant.Phone = txtboxPhone.Text;
                var selectedLoc = listLocation.SelectedValue.Split('|');
                applicant.LocationId = Convert.ToInt32(selectedLoc[0]);
                applicant.SubLocationId = Convert.ToInt32(selectedLoc[1]);
                applicant.IndustryId = Convert.ToInt32(listIndustry.SelectedValue);
                applicant.SalaryRangeId = Convert.ToInt32(listSalaryRange.SelectedValue);

                OnSubmitApplicantCreate(new ApplicantEventArgs(applicant, true));
            }
        }

        protected void OnSubmitApplicantCreate(ApplicantEventArgs e)
        {
            if (SubmitApplicantCreate != null)
            {
                SubmitApplicantCreate(this, e);
            }
        }
    }
}