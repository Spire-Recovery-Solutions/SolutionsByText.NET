using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Webhooks
{
    /// <summary>
    /// Represents the payload for SmartURL click webhooks, extending the base webhook payload.
    /// </summary>
    public class SmartUrlClickRequest : WebhookPayload
    {
        /// <summary>
        /// Gets or sets the payload containing the data related to the SmartURL click event.
        /// </summary>
        [JsonPropertyName("Payload")]
        public SmartUrlClickData Payload { get; set; }
    }
}
