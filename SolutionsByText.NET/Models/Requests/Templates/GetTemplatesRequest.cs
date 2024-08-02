using SolutionsByText.NET.Models.Responses;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Templates
{
    public class GetTemplatesRequest : PaginationData
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// The search term to filter results.
        /// </summary>
        [JsonPropertyName("search")]
        public string? Search { get; set; }
    }
}
