using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class PaginatedSmartUrlReport : PaginationData
    {
        /// <summary>
        /// Gets or sets the list of SmartURL click reports.
        /// </summary>
        [JsonPropertyName("data")] 
        public List<SmartUrlClickReport> SmartUrlClickReport { get; set; }
    }
}
