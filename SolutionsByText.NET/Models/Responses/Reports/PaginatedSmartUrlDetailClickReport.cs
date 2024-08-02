using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class PaginatedSmartUrlDetailClickReport : PaginationData
    {
        /// <summary>
        /// Gets or sets the list of detailed click reports for SmartURLs.
        /// </summary>
        [JsonPropertyName("data")]
        public List<SmartUrlDetailClickReport>? SmartUrlDetailClickReport { get; set; }
    }
}
