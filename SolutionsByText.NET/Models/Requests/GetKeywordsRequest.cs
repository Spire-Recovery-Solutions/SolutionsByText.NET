using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    public class GetKeywordsRequest
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

        /// <summary>
        /// The page number for pagination.
        /// </summary>
        [JsonPropertyName("pageNumber")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// The number of items to return per page.
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }
    }
}
