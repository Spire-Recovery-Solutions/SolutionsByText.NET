using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class GetAllSmartUrlRequest : PaginationData
    {
        /// <summary>
        /// The unique identifier for the SmartURL.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// The creation date of the SmartURL.
        /// </summary>
        [JsonPropertyName("fromDate")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// To date the SmartURL.
        /// </summary>
        [JsonPropertyName("toDate")]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Search smart urls by text
        /// </summary>
        [JsonPropertyName("search")]
        public string? Search { get; set; }

        /// <summary>
        /// The short URL string.
        /// </summary>
        [JsonPropertyName("shortUrl")]
        public string? ShortUrl { get; set; }
    }
}
