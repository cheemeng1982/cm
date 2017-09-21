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
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;


namespace JABackendService
{
    public class UserManager
    {
        public int InsertApplicant(ApplicantDto applicant, out string message)
        {
            int ret = 0;
            using (SqlConnection conn = Repository.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        ret = UserProvider.InsertApplicant(conn, trans, applicant);
                        trans.Commit();
                        message = string.Format("Applicant created successfully. ApplicantId = {0}", ret);
                    }
                    catch
                    {
                        trans.Rollback();
                        message = "Fail to create user. Please try again.";
                        throw;
                    }
                }
            }
            return ret;
        }

        public List<LocationDto> GetLocationList()
        {
            List<LocationDto> list = new List<LocationDto>();
            using (SqlConnection conn = Repository.GetDBConnection())
            {
                conn.Open();
                list = UserProvider.GetLocationList(conn);
            }
            return list;
        }

        public List<IndustryDto> GetIndustryList()
        {
            List<IndustryDto> list = new List<IndustryDto>();
            using (SqlConnection conn = Repository.GetDBConnection())
            {
                conn.Open();
                list = UserProvider.GetIndustryList(conn);
            }
            return list;
        }

        public List<SalaryRangeDto> GetSalaryRangeList()
        {
            List<SalaryRangeDto> list = new List<SalaryRangeDto>();
            using (SqlConnection conn = Repository.GetDBConnection())
            {
                conn.Open();
                list = UserProvider.GetSalaryRangeList(conn);
            }
            return list;
        }

        public List<ApplicantDto> RetrieveApplicantListByPaging(int pageSize, int pageIndex)
        {
            List<ApplicantDto> list = new List<ApplicantDto>();
            using (SqlConnection conn = Repository.GetDBConnection())
            {
                conn.Open();
                list = UserProvider.GetApplicantList(conn, pageSize, pageIndex);
            }
            return list;
        }

        public List<ApplicantDto> RetrieveAllApplicants()
        {
            List<ApplicantDto> list = new List<ApplicantDto>();
            using (SqlConnection conn = Repository.GetDBConnection())
            {
                conn.Open();
                list = UserProvider.GetAllApplicants(conn);
            }
            return list;
        }
    }
}
