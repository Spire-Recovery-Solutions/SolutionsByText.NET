using SolutionsByText.NET.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    public class GetKeywordsRequest : PaginationData
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Optional filter to apply to the keywords.
        /// </summary>
        [JsonPropertyName("filter")]
        public string? Filter { get; set; }
    }
}
