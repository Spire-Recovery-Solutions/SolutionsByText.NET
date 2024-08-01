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
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the PIN provided by the subscriber.
        /// </summary>
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
    }
}
