using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{

    /// <summary>
    /// Represents the response received after requesting outbound messages.
    /// </summary>
    public class GetOutboundMessagesResponse
    {
        /// <summary>
        /// Gets or sets the list of outbound messages.
        /// </summary>
        [JsonPropertyName("messages")]
        public List<OutboundMessage> Messages { get; set; }
    }

}
