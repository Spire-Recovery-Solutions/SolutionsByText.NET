using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{

    /// <summary>
    /// Represents the status of a single subscriber.
    /// </summary>
    public class SubscriberStatus
    {
        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the status of the subscriber.
        /// </summary>
        [JsonPropertyName("status")]
        public SubscriptionStatus Status { get; set; }
    }
}
