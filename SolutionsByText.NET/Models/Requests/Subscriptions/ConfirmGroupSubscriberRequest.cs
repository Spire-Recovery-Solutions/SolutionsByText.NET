using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscriptions
{

    /// <summary>
    /// Represents a request to confirm a subscriber's opt-in using a PIN.
    /// </summary>
    public class ConfirmGroupSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

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
