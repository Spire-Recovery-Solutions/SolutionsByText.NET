using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class PaginatedSmartUrlClickReport : PaginationData
    {
        /// <summary>
        /// Gets or sets the list of SmartURL click reports.
        /// </summary>
        [JsonPropertyName("data")]
        public List<SmartUrlClickReport>? SmartUrlClickReport { get; set; }
    }
}
