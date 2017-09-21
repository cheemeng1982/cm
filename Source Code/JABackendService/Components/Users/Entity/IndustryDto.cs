using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JABackendService
{
    public class IndustryDto
    {
        [JsonProperty("iid")]
        public int IndustryId { get; set; }
        [JsonProperty("in")]
        public string IndustryName { get; set; }
    }
}