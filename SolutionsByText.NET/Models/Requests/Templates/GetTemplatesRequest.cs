using SolutionsByText.NET.Models.Responses;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Templates
{
    public class GetTemplatesRequest : PaginationData
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// The search term to filter results.
        /// </summary>
        [JsonIgnore]
        public string? Search { get; set; }
    }
}
