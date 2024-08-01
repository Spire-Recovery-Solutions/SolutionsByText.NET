using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Webhooks
{
    /// <summary>
    /// Represents the request structure for an inbound message containing the message payload.
    /// </summary>
    public class InboundMessageRequest : WebhookPayload
    {
        /// <summary>
        /// Gets or sets the payload containing the details of the inbound message.
        /// </summary>
        [JsonPropertyName("Payload")]
        public InboundMessageData Payload { get; set; }
    }
}