using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Webhooks
{
    /// <summary>
    /// Represents the status data for an outbound message, including its delivery status and metadata.
    /// </summary>
    public class OutboundMessageStatusData
    {
        /// <summary>
        /// Gets or sets the unique identifier for the account associated with the message.
        /// </summary>
        [JsonPropertyName("AccountId")]
        public string? AccountId { get; set; }

        /// <summary>
        /// Gets or sets the content of the message sent.
        /// </summary>
        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the MSISDN (Mobile Station International Subscriber Directory Number) of the recipient.
        /// </summary>
        [JsonPropertyName("Msisdn")]
        public string? Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the name of the group associated with the message.
        /// </summary>
        [JsonPropertyName("GroupName")]
        public string? GroupName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the group associated with the message.
        /// </summary>
        [JsonPropertyName("GroupId")]
        public string? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the communication code that indicates the type of communication.
        /// </summary>
        [JsonPropertyName("CommunicationCode")]
        public string? CommunicationCode { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was delivered.
        /// </summary>
        [JsonPropertyName("DeliveredTime")]
        public DateTime DeliveredTime { get; set; }

        /// <summary>
        /// Gets or sets a list of additional properties related to the message.
        /// </summary>
        [JsonPropertyName("Properties")]
        public List<Property>? Properties { get; set; }

        /// <summary>
        /// Gets or sets the status code indicating the delivery status of the message.
        /// </summary>
        [JsonPropertyName("StatusCode")]
        public string? StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the description of the status code.
        /// </summary>
        [JsonPropertyName("StatusCodeDescription")]
        public string? StatusCodeDescription { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the message itself.
        /// </summary>
        [JsonPropertyName("MessageId")]
        public string? MessageId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier for tracking the message.
        /// </summary>
        [JsonPropertyName("ReferenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the channel through which the message was sent (e.g., SMS, MMS).
        /// </summary>
        [JsonPropertyName("Channel")]
        public string? Channel { get; set; }

        /// <summary>
        /// Gets or sets the total number of message segments if the message was split.
        /// </summary>
        [JsonPropertyName("TotalMessageSegments")]
        public int? TotalMessageSegments { get; set; }

        /// <summary>
        /// Gets or sets the type of message (e.g., text, image, etc.).
        /// </summary>
        [JsonPropertyName("MessageType")]
        public string? MessageType { get; set; }

        /// <summary>
        /// Gets or sets the list of media files associated with the outbound message.
        /// </summary>
        [JsonPropertyName("Files")]
        public List<MediaFile>? Files { get; set; }
    }
}