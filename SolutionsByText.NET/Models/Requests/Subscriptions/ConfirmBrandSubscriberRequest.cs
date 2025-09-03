using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscriptions
{
    /// <summary>
    /// Represents a request to confirm a subscriber's opt-in for a brand using a PIN.
    /// </summary>
    public class ConfirmBrandSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the brand.
        /// </summary>
        [JsonIgnore]
        public string BrandId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonIgnore]
        public string Msisdn { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the PIN provided by the subscriber.
        /// </summary>
        [JsonPropertyName("pin")]
        public required string Pin { get; set; }
    }
}
