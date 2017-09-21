using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JABackendService
{
    public class LocationDto
    {
        [JsonProperty("lid")]
        public int LocationId { get; set; }
        [JsonProperty("slid")]
        public int SubLocationId { get; set; }
        [JsonProperty("lc")]
        public string LocationName { get; set; }
        [JsonProperty("slc")]
        public string SubLocationName { get; set; }
    }
}