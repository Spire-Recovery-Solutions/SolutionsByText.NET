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
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// The creation date of the SmartURL.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? FromDate { get; set; }

        /// <summary>
        /// To date the SmartURL.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? ToDate { get; set; }

        /// <summary>
        /// Search smart urls by text
        /// </summary>
        [JsonIgnore]
        public string? Search { get; set; }

        /// <summary>
        /// The short URL string.
        /// </summary>
        [JsonIgnore]
        public string? ShortUrl { get; set; }
    }
}
