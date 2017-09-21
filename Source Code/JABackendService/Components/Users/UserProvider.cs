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
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace JABackendService
{
    public class UserProvider
    {
        internal static List<ApplicantDto> GetApplicantList(SqlConnection connection, int pageSize, int pageIndex)
        {
            SqlCommand cmdApplicant = Repository.GetSQLCommand(StoredProcedure.SP_p_tbl_Applicant_retrieve_paging, connection);
     
            cmdApplicant.Parameters.Add("@xPageSize", SqlDbType.Int);
            cmdApplicant.Parameters[0].Value = pageSize;
            cmdApplicant.Parameters.Add("@xPageIndex", SqlDbType.Int);
            cmdApplicant.Parameters[1].Value = pageIndex;
            cmdApplicant.ExecuteNonQuery();
         
            List<ApplicantDto> applicants = null;
            using (SqlDataReader tempDataReader = cmdApplicant.ExecuteReader())
            {
                if (tempDataReader.HasRows)
                {
                    applicants = new List<ApplicantDto>();
                    while (tempDataReader.Read())
                    {
                        var applicant = new ApplicantDto();
                        applicant.ApplicantId = Convert.ToInt32(tempDataReader["ApplicantId"]);
                        applicant.FirstName = tempDataReader["FirstName"].ToString();
                        applicant.LastName = tempDataReader["LastName"].ToString();
                        applicant.CompanyName = tempDataReader["CompanyName"].ToString();
                        applicant.Phone = tempDataReader["Phone"].ToString();
                        applicant.Email = tempDataReader["Email"].ToString();
                        applicant.CorrespondenceAddress = tempDataReader["CorrespondenceAddress"].ToString();
                        applicant.JobTitle = tempDataReader["JobTitle"].ToString();
                        applicant.JobSpecification = tempDataReader["JobSpecification"].ToString();
                        applicant.IndustryName = tempDataReader["IndustryName"].ToString();
                        applicant.LocationName = tempDataReader["LocationName"].ToString();
                        applicant.SubLocationName = tempDataReader["SubLocationName"].ToString();
                        applicant.SalaryRange = tempDataReader["SalaryRange"].ToString();

                        applicants.Add(applicant);
                    }
                }
            }
            return applicants;
        }

        internal static List<ApplicantDto> GetAllApplicants(SqlConnection connection)
        {
            SqlCommand cmdApplicant = Repository.GetSQLCommand(StoredProcedure.SP_p_tbl_Applicant_retrieve_all, connection);

            cmdApplicant.ExecuteNonQuery();
    
            List<ApplicantDto> applicants = null;
            using (SqlDataReader tempDataReader = cmdApplicant.ExecuteReader())
            {
                if (tempDataReader.HasRows)
                {
                    applicants = new List<ApplicantDto>();
                    while (tempDataReader.Read())
                    {
                        var applicant = new ApplicantDto();
                        applicant.ApplicantId = Convert.ToInt32(tempDataReader["ApplicantId"]);
                        applicant.FirstName = tempDataReader["FirstName"].ToString();
                        applicant.LastName = tempDataReader["LastName"].ToString();
                        applicant.CompanyName = tempDataReader["CompanyName"].ToString();
                        applicant.Phone = tempDataReader["Phone"].ToString();
                        applicant.Email = tempDataReader["Email"].ToString();
                        applicant.CorrespondenceAddress = tempDataReader["CorrespondenceAddress"].ToString();
                        applicant.JobTitle = tempDataReader["JobTitle"].ToString();
                        applicant.JobSpecification = tempDataReader["JobSpecification"].ToString();
                        applicant.IndustryName = tempDataReader["IndustryName"].ToString();
                        applicant.LocationName = tempDataReader["LocationName"].ToString();
                        applicant.SubLocationName = tempDataReader["SubLocationName"].ToString();
                        applicant.SalaryRange = tempDataReader["SalaryRange"].ToString();

                        applicants.Add(applicant);
                    }
                }
            }
            return applicants;
        }


        internal static List<LocationDto> GetLocationList(SqlConnection connection)
        {
            SqlCommand cmdApplicant = Repository.GetSQLCommand(StoredProcedure.SP_p_tbl_LookupLocationSubLocation_retrieve_all, connection);
               
            cmdApplicant.ExecuteNonQuery();
            string password = string.Empty;

            List<LocationDto> locations = null;
            using (SqlDataReader tempDataReader = cmdApplicant.ExecuteReader())
            {
                if (tempDataReader.HasRows)
                {
                    locations = new List<LocationDto>();
                    while (tempDataReader.Read())
                    {
                        var loc = new LocationDto();
                        loc.LocationId = Convert.ToInt32(tempDataReader["LocationId"]);
                        loc.LocationName = tempDataReader["LocationName"].ToString();
                        loc.SubLocationId = Convert.ToInt32(tempDataReader["SubLocationId"]);
                        loc.SubLocationName = tempDataReader["SubLocationName"].ToString();

                        locations.Add(loc);
                    }
                }
            }

            return locations;
        }

        internal static List<IndustryDto> GetIndustryList(SqlConnection connection)
        {
            SqlCommand cmdApplicant = Repository.GetSQLCommand(StoredProcedure.SP_p_tbl_LookupIndustry_retrieve_all, connection);

            cmdApplicant.ExecuteNonQuery();
            string password = string.Empty;

            List<IndustryDto> industries = null;
            using (SqlDataReader tempDataReader = cmdApplicant.ExecuteReader())
            {
                if (tempDataReader.HasRows)
                {
                    industries = new List<IndustryDto>();
                    while (tempDataReader.Read())
                    {
                        var ind = new IndustryDto();
                        ind.IndustryId = Convert.ToInt32(tempDataReader["IndustryId"]);
                        ind.IndustryName = tempDataReader["IndustryName"].ToString();
                       
                        industries.Add(ind);
                    }
                }
            }

            return industries;
        }

        internal static List<SalaryRangeDto> GetSalaryRangeList(SqlConnection connection)
        {
            SqlCommand cmdApplicant = Repository.GetSQLCommand(StoredProcedure.SP_p_tbl_LookupSalaryRange_retrieve_all, connection);

            cmdApplicant.ExecuteNonQuery();
            string password = string.Empty;

            List<SalaryRangeDto> salaries = null;
            using (SqlDataReader tempDataReader = cmdApplicant.ExecuteReader())
            {
                if (tempDataReader.HasRows)
                {
                    salaries = new List<SalaryRangeDto>();
                    while (tempDataReader.Read())
                    {
                        var s = new SalaryRangeDto();
                        s.SalaryRangeId = Convert.ToInt32(tempDataReader["SalaryRangeId"]);
                        s.Display = tempDataReader["Display"].ToString();
                      
                        salaries.Add(s);
                    }
                }
            }

            return salaries;
        }

        internal static int InsertApplicant (SqlConnection connection, SqlTransaction txnApplicant, ApplicantDto applicant)
        {
            SqlCommand cmdApplicant = Repository.GetSQLCommand(StoredProcedure.SP_p_tbl_Applicant_insert, connection);
            cmdApplicant.Transaction = txnApplicant;

            cmdApplicant.Parameters.Add("@xFirstName", SqlDbType.NVarChar);
            cmdApplicant.Parameters[0].Value = applicant.FirstName;
            cmdApplicant.Parameters.Add("@xLastName", SqlDbType.NVarChar);
            cmdApplicant.Parameters[1].Value = applicant.LastName;
            cmdApplicant.Parameters.Add("@xCompanyName", SqlDbType.NVarChar);
            cmdApplicant.Parameters[2].Value = applicant.CompanyName;
            cmdApplicant.Parameters.Add("@xPhone", SqlDbType.NVarChar);
            cmdApplicant.Parameters[3].Value = applicant.Phone;
            cmdApplicant.Parameters.Add("@xEmail", SqlDbType.NVarChar);
            cmdApplicant.Parameters[4].Value = applicant.Email;
            cmdApplicant.Parameters.Add("@xCorrespondenceAddress", SqlDbType.NVarChar);
            cmdApplicant.Parameters[5].Value = applicant.CorrespondenceAddress;
            cmdApplicant.Parameters.Add("@xJobTitle", SqlDbType.NVarChar);
            cmdApplicant.Parameters[6].Value = applicant.JobTitle;
            cmdApplicant.Parameters.Add("@xJobSpecification", SqlDbType.NVarChar);
            cmdApplicant.Parameters[7].Value = applicant.JobSpecification;
            cmdApplicant.Parameters.Add("@xLocationId", SqlDbType.Int);
            cmdApplicant.Parameters[8].Value = applicant.LocationId;
            cmdApplicant.Parameters.Add("@xSubLocationId", SqlDbType.Int);
            cmdApplicant.Parameters[9].Value = applicant.SubLocationId;
            cmdApplicant.Parameters.Add("@xIndustryId", SqlDbType.Int);
            cmdApplicant.Parameters[10].Value = applicant.IndustryId;
            cmdApplicant.Parameters.Add("@xSalaryRangeId", SqlDbType.Int);
            cmdApplicant.Parameters[11].Value = applicant.SalaryRangeId;


            cmdApplicant.Parameters.Add("@ReturnValue", SqlDbType.Int);
            cmdApplicant.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;

            cmdApplicant.ExecuteNonQuery();
            // In stored proc standards, zero equals success
            int retVal = 0;
            retVal = (int)cmdApplicant.Parameters["@ReturnValue"].Value;
            cmdApplicant.Dispose();

            if (retVal < 0)
            {
                // throw exception
                throw new DataException(String.Format("Fail to insert new applicant \"{0}\".", applicant.FirstName + " " + applicant.LastName));
            }

            return retVal;
        }
    }
}
