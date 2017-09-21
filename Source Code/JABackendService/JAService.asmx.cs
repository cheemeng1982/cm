using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;

namespace JABackendService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class JAService : System.Web.Services.WebService
    {

        [WebMethod]
        public int AddApplicant (string jsonUser, out string message)
        {
            var applicant = JsonConvert.DeserializeObject<ApplicantDto>(jsonUser);
            UserManager userManager = new UserManager();
            return userManager.InsertApplicant(applicant, out message);
        }

        [WebMethod]
        public List<LocationDto> GetLocations()
        {
            UserManager userManager = new UserManager();
            return userManager.GetLocationList();
        }

        [WebMethod]
        public List<IndustryDto> GetIndustries()
        {
            UserManager userManager = new UserManager();
            return userManager.GetIndustryList();
        }

        [WebMethod]
        public List<SalaryRangeDto> GetSalaryRanges()
        {
            UserManager userManager = new UserManager();
            return userManager.GetSalaryRangeList();
        }

        [WebMethod]
        public List<ApplicantDto> RetrieveApplicantListByPaging(int pageSize, int pageIndex)
        {
            UserManager userManager = new UserManager();
            return userManager.RetrieveApplicantListByPaging(pageSize, pageIndex);
        }

        [WebMethod]
        public List<ApplicantDto> RetrieveAllApplicants()
        {
            UserManager userManager = new UserManager();
            return userManager.RetrieveAllApplicants();
        }
    }
}
