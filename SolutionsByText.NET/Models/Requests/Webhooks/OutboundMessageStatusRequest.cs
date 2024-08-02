using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Webhooks
{
    /// <summary>
    /// Represents the payload for outbound message status webhooks, extending the base webhook payload.
    /// </summary>
    public class OutboundMessageStatusRequest : WebhookPayload
    {
        /// <summary>
        /// Gets or sets the payload containing the status data for the outbound message.
        /// </summary>
        [JsonPropertyName("Payload")]
        public OutboundMessageStatusData? Payload { get; set; }
    }
}