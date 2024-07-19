using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{

    /// <summary>
    /// Represents the response received after requesting inbound messages.
    /// </summary>
    public class GetInboundMessagesResponse
    {
        /// <summary>
        /// Gets or sets the list of inbound messages.
        /// </summary>
        [JsonPropertyName("messages")]
        public List<InboundMessage> Messages { get; set; }
    }
}
