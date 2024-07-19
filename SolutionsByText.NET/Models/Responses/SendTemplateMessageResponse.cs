using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response received after sending a template message.
    /// </summary>
    public class SendTemplateMessageResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the sent message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the status of the sent message.
        /// </summary>
        [JsonPropertyName("status")]
        public MessageStatus Status { get; set; }
    }
}
