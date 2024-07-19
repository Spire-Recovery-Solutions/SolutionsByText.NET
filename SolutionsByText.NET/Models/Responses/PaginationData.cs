using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the pagination details for a paginated response.
    /// </summary>
    public class PaginationData
    {
        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total count of items.
        /// </summary>
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

    }
}