using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents a single inbound message.
    /// </summary>
    public class InboundMessage
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
        /// Gets or sets the phone number of the sender.
        /// </summary>
        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was received.
        /// </summary>
        [JsonPropertyName("receivedDateTime")]
        public DateTime ReceivedDateTime { get; set; }
    }
}
