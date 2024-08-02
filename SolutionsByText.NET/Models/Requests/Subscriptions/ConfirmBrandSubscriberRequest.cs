using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscription
{
    /// <summary>
    /// Represents a request to confirm a subscriber's opt-in for a brand using a PIN.
    /// </summary>
    public class ConfirmBrandSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the brand.
        /// </summary>
        [JsonPropertyName("brandId")]
        public required string BrandId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public required string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the PIN provided by the subscriber.
        /// </summary>
        [JsonPropertyName("pin")]
        public required string Pin { get; set; }
    }
}
