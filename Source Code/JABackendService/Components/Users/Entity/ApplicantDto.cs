using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JABackendService
{
    public class ApplicantDto
    {
        public int ApplicantId { get; set; }
   
        public string FirstName { get; set; }
  
        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CorrespondenceAddress { get; set; }

        public string JobTitle { get; set; }

        public string JobSpecification { get; set; }

        public int LocationId { get; set; }

        public string LocationName { get; set; }
 
        public int SubLocationId { get; set; }

        public string SubLocationName { get; set; }

        public int IndustryId { get; set; }

        public string IndustryName { get; set; }

        public int SalaryRangeId { get; set; }

        public string SalaryRange { get; set; }

        public DateTime CreationDate { get; set; }
    }
}