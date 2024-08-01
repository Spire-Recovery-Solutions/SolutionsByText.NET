using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class GetAllSubscribersGroupRequest : PaginationData
    {
        /// <summary>
        /// The group ID. This is a required parameter.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// A string that the search results should start with. This is an optional parameter.
        /// </summary>
        [JsonPropertyName("startsWith")]
        public string? StartsWith { get; set; }

        /// <summary>
        /// A search query string. This is an optional parameter.
        /// </summary>
        [JsonPropertyName("search")]
        public string? Search { get; set; }

        /// <summary>
        /// The start date for filtering results. This is an optional parameter.
        /// </summary>
        [JsonPropertyName("from")]
        public string? From { get; set; }

        /// <summary>
        /// The end date for filtering results. This is an optional parameter.
        /// </summary>
        [JsonPropertyName("to")]
        public string? To { get; set; }
    }
}
