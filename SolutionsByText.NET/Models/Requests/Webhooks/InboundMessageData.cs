using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Webhooks
{
    /// <summary>
    /// Represents the data structure for an inbound message request.
    /// </summary>
    public class InboundMessageData
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
        /// Gets or sets the original content of the message before any modifications.
        /// </summary>
        [JsonPropertyName("OriginalMessage")]
        public string? OriginalMessage { get; set; }

        /// <summary>
        /// Gets or sets the MSISDN (Mobile Station International Subscriber Directory Number) of the sender.
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
        /// Gets or sets the type of message (e.g., text, image, etc.).
        /// </summary>
        [JsonPropertyName("MessageType")]
        public string? MessageType { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was received.
        /// </summary>
        [JsonPropertyName("ReceivedTime")]
        public DateTime ReceivedTime { get; set; }

        /// <summary>
        /// Gets or sets a list of additional properties related to the message.
        /// </summary>
        [JsonPropertyName("Properties")]
        public List<Property>? Properties { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier for tracking the message.
        /// </summary>
        [JsonPropertyName("ReferenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the message itself.
        /// </summary>
        [JsonPropertyName("MessageId")]
        public string? MessageId { get; set; }
    }
}