using System;
using System.Text.Json.Serialization;
using SolutionsByText.NET.Models.Requests.Enums;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    /// <summary>
    /// Represents a request to get details of inbound messages for a specific group.
    /// </summary>
    public class GetInboundMessagesRequest : PaginationData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group. (Required)
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the reference identifier for tracking. (Optional)
        /// </summary>
        [JsonIgnore]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the start date for the report in ISO 8601 format. (Required)
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? FromDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for the report in ISO 8601 format. (Required)
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the time zone offset for filtering. (Optional)
        /// </summary>
        [JsonIgnore]
        public string? TimeZoneOffset { get; set; }

        /// <summary>
        /// Gets or sets the type of inbound message. (Optional)
        /// </summary>
        [JsonIgnore]
        public InboundMessageType? Type { get; set; }
    }
}
