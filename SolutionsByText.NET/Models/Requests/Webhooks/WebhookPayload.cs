using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Webhooks
{
    /// <summary>
    /// Base class for all webhook payloads, providing a common structure for derived payload types.
    /// </summary>
    public abstract class WebhookPayload
    {
        /// <summary>
        /// Gets or sets the type of the webhook payload, indicating the specific event or data type.
        /// </summary>
        [JsonPropertyName("Type")]
        public string Type { get; set; }
    }
}