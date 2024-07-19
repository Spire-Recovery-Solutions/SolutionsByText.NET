using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response received after sending a message, containing relevant details.
    /// </summary>
    public class SendMessageResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sent message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
    }
}