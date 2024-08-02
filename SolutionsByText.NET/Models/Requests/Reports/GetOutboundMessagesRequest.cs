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
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the message identifier for tracking the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string? MessageId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier for tracking.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the start date for the report in mm/dd/yyyy hh:mm:ss format.
        /// </summary>
        [JsonPropertyName("fromDate")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for the report in mm/dd/yyyy hh:mm:ss format.
        /// </summary>
        [JsonPropertyName("toDate")]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the timezone offset.
        /// </summary>
        [JsonPropertyName("timeZoneOffset")]
        public string? TimeZoneOffset { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        [JsonPropertyName("type")]
        public OutboundMessageType? Type { get; set; }
    }
}
