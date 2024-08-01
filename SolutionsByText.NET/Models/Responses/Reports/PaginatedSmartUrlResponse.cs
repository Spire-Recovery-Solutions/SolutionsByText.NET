using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class PaginatedSmartUrlResponse : PaginationData
    {
        /// <summary>
        /// Gets or sets the list of Smart URL data items.
        /// </summary>
        [JsonPropertyName("data")]
        public List<SmartUrlItem> Data { get; set; }
    }
}