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
        /// The identifier of the group being polled.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// A string that the search results should start with. This is an optional parameter.
        /// </summary>
        [JsonIgnore]
        public string? StartsWith { get; set; }

        /// <summary>
        /// A search query string. This is an optional parameter.
        /// </summary>
        [JsonIgnore]
        public string? Search { get; set; }

        /// <summary>
        /// Start date of query. Default is first of the current month. Must include the *to* date or omitted; an error will result otherwise.
        /// </summary>
        [JsonIgnore]
        public string? From { get; set; }

        /// <summary>
        /// End date of query. Default is the current date. Must include the *from* date or omitted; an error will result otherwise.
        /// </summary>
        [JsonIgnore]
        public string? To { get; set; }
    }
}
