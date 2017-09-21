using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JABackendService
{
    public class SalaryRangeDto
    {
        [JsonProperty("srid")]
        public int SalaryRangeId { get; set; }
        [JsonProperty("sd")]
        public string Display { get; set; }
    }
}