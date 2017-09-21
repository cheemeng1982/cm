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
using System.IO;
using System.Text;

namespace JABackendService
{
    public static class Repository
    {
        #region Constant
        private const string DB_CONNECTION = "DBJAWebConnection";
        #endregion

        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[DB_CONNECTION].ConnectionString);
        }

        public static SqlCommand GetSQLCommand(string storedProcedureName, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(storedProcedureName, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }
    }

    public static class StoredProcedure
    {
        #region Stored Procedures Constant
        public const string SP_p_tbl_Applicant_insert = "sp_tbl_Applicant_insert";
        public const string SP_p_tbl_Applicant_retrieve_paging = "sp_tbl_Applicant_retrieve_paging";
        public const string SP_p_tbl_Applicant_retrieve_all = "sp_tbl_Applicant_retrieve_all";

        public const string SP_p_tbl_LookupLocationSubLocation_retrieve_all = "sp_tbl_LookupLocationSubLocation_retrieve_all";
        public const string SP_p_tbl_LookupSalaryRange_retrieve_all = "sp_tbl_LookupSalaryRange_retrieve_all";
        public const string SP_p_tbl_LookupIndustry_retrieve_all = "sp_tbl_LookupIndustry_retrieve_all";
     
        #endregion
    }
}
