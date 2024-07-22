using System;
using System.Text.Json.Serialization;
using SolutionsByText.NET.Models.Requests.Enums;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to get details of inbound messages for a specific group.
    /// </summary>
    public class GetInboundMessagesRequest : PaginationData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group. (Required)
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier for tracking. (Optional)
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the start date for the report in mm/dd/yyyy hh:mm:ss format. (Required)
        /// </summary>
        [JsonPropertyName("fromDate")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for the report in mm/dd/yyyy hh:mm:ss format. (Required)
        /// </summary>
        [JsonPropertyName("toDate")]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the time zone offset for filtering. (Optional)
        /// </summary>
        [JsonPropertyName("timeZoneOffset")]
        public string? TimeZoneOffset { get; set; }

        /// <summary>
        /// Gets or sets the type of inbound message. (Optional)
        /// </summary>
        [JsonPropertyName("type")]
        public InboundMessageType? Type { get; set; }
    }
}
