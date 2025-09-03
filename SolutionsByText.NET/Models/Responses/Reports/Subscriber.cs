using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents the paginated subscriber data structure.
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// Maximum number of pages in the query return.
        /// </summary>
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Number of items on each returned page.
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Number of pages in the query return.
        /// </summary>
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Total number of items in the query return.
        /// </summary>
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Array of subscriber data.
        /// </summary>
        [JsonPropertyName("data")]
        public List<SubscriberData>? Data { get; set; }
    }
}