using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class PaginatedAllSubscribersGroup : PaginationData
    {
        /// <summary>
        /// All Subs Group Details
        /// </summary>
        [JsonPropertyName("data")]
        public List<AllSubscriberGroup>? Items { get; set; }
    }
}
