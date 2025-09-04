using SolutionsByText.NET.Models.Requests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class GetBrandVbtOutboundMessageRequest : PaginationData
    {
        /// <summary>
        /// Required: The unique identifier for the brand
        /// </summary>
        [JsonIgnore]
        public string BrandId { get; set; } = string.Empty;

        /// <summary>
        /// Tracking ID for the opt-in verification message.
        /// </summary>
        [JsonIgnore]
        public string? MessageId { get; set; }

        /// <summary>
        /// Tracking ID for reference notes.
        /// </summary>
        [JsonIgnore]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Start date-time for filtering messages.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? FromDate { get; set; }

        /// <summary>
        /// End date-time for filtering messages.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? ToDate { get; set; }

        /// <summary>
        /// Timezone offset for retrieving details.
        /// </summary>
        [JsonIgnore]
        public string? TimeZoneOffset { get; set; }

        /// <summary>
        /// Type of the message (Enum values).
        /// </summary>
        [JsonIgnore]
        public OutboundMessageType? Type { get; set; }
    }
}
