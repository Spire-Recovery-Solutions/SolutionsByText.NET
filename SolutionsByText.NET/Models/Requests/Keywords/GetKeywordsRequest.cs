using SolutionsByText.NET.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Keywords
{
    public class GetKeywordsRequest : PaginationData
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Optional filter to apply to the keywords.
        /// </summary>
        [JsonIgnore]
        public string? Filter { get; set; }
    }
}
