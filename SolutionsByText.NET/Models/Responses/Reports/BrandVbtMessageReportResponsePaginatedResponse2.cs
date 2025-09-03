using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents the paginated response for brand VBT message reports as specified by the API.
    /// </summary>
    public class BrandVbtMessageReportResponsePaginatedResponse2
    {
        /// <summary>
        /// Gets or sets the total number of items.
        /// </summary>
        [JsonPropertyName("totalCount")]
        public long? TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        [JsonPropertyName("totalPages")]
        public int? TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the data array containing the brand VBT message reports.
        /// </summary>
        [JsonPropertyName("data")]
        public List<BrandVbtMessageReportResponse>? Data { get; set; }
    }
}