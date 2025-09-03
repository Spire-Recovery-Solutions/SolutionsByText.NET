using SolutionsByText.NET.Models.Requests.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    /// <summary>
    /// Represents a request to get details of outbound messages for a specific group.
    /// </summary>
    public class GetOutboundMessagesRequest : PaginationData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the message identifier for tracking the message.
        /// </summary>
        [JsonIgnore]
        public string? MessageId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier for tracking.
        /// </summary>
        [JsonIgnore]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the start date for the report in mm/dd/yyyy hh:mm:ss format.
        /// </summary>
        [JsonIgnore]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for the report in mm/dd/yyyy hh:mm:ss format.
        /// </summary>
        [JsonIgnore]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the timezone offset.
        /// </summary>
        [JsonIgnore]
        public string? TimeZoneOffset { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        [JsonIgnore]
        public OutboundMessageType? Type { get; set; }
    }
}
