using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents a single outbound message.
    /// </summary>
    public class OutboundMessage
    {
        /// <summary>
        /// Gets or sets the unique identifier of the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the status of the message.
        /// </summary>
        [JsonPropertyName("status")]
        public MessageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was sent.
        /// </summary>
        [JsonPropertyName("sentDateTime")]
        public DateTime SentDateTime { get; set; }
    }
}