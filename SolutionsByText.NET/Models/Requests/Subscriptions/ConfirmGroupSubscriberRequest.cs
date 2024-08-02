using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscription
{

    /// <summary>
    /// Represents a request to confirm a subscriber's opt-in using a PIN.
    /// </summary>
    public class ConfirmGroupSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

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
