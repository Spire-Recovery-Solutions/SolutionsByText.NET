using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class GetSmartUrlReportRequest : PaginationData
    {
        /// <summary>
        /// The unique identifier for the brand.
        /// </summary>
        [JsonPropertyName("brandId")]
        public required string BrandId { get; set; }

        /// <summary>
        /// Indicates if a custom suffix is used.
        /// </summary>
        [JsonPropertyName("isCustomSuffix")]
        public bool? IsCustomSuffix { get; set; }

        /// <summary>
        /// The specific short URL to filter results.
        /// </summary>
        [JsonPropertyName("shortUrl")]
        public string? ShortUrl { get; set; }

        /// <summary>
        /// The start date for the date range.
        /// Accepts format: ISO 8601 (e.g., 2025-01-01T00:00:00Z)
        /// Default: "1st of the current month"
        /// </summary>
        [JsonPropertyName("fromDate")]
        public DateTimeOffset? FromDate { get; set; }

        /// <summary>
        /// The end date for the date range.
        /// Accepts format: ISO 8601 (e.g., 2025-01-01T23:59:59Z)
        /// Default: "Current Date"
        /// </summary>
        [JsonPropertyName("toDate")]
        public DateTimeOffset? ToDate { get; set; }

        /// <summary>
        /// The time zone offset for the date range.
        /// Default: "-00:00"
        /// </summary>
        [JsonPropertyName("timeZoneOffset")]
        public string? TimeZoneOffset { get; set; }
    }
}
