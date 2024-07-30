using SolutionsByText.NET.Models.Requests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    public class GetBrandVbtInboundMessageRequest : PaginationData
    {
        // Required: The unique identifier for the brand
        [JsonPropertyName("brandId")] public string BrandId { get; set; }

        /// <summary>
        /// Tracking ID for reference notes.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Start date-time for filtering messages.
        /// </summary>
        [JsonPropertyName("fromDate")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// End date-time for filtering messages.
        /// </summary>
        [JsonPropertyName("toDate")]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Timezone offset for retrieving details.
        /// </summary>
        [JsonPropertyName("timeZoneOffset")]
        public string? TimeZoneOffset { get; set; }

        /// <summary>
        /// Type of the message (Enum values).
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InboundMessageType? Type { get; set; }
    }
}
