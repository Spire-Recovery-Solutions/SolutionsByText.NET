using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents the request structure for an inbound message containing the message payload.
    /// </summary>
    public class InboundMessageRequest
    {
        /// <summary>
        /// Gets or sets the payload containing the details of the inbound message.
        /// </summary>
        [JsonPropertyName("Payload")]
        public InboundMessageData Payload { get; set; }
    }
}