using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to get details of outbound messages for a specific group.
    /// </summary>
    public class GetOutboundMessagesRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the start date for the report.
        /// </summary>
        [JsonPropertyName("fromDate")]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for the report.
        /// </summary>
        [JsonPropertyName("toDate")]
        public DateTime ToDate { get; set; }
    }
}
