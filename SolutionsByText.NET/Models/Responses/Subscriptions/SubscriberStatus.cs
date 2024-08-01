using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Subscriptions
{

    /// <summary>
    /// Represents the status of a single subscriber.
    /// </summary>
    public class SubscriberStatus
    {
        /// <summary>
        /// Gets or sets the status of the subscriber.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the name of the carrier.
        /// </summary>
        [JsonPropertyName("carrierName")]
        public string CarrierName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the carrier.
        /// </summary>
        [JsonPropertyName("carrierId")]
        public string CarrierId { get; set; }

        /// <summary>
        /// Gets or sets the first opt-in date.
        /// </summary>
        [JsonPropertyName("firstOptInDate")]
        public DateTime FirstOptInDate { get; set; }

        /// <summary>
        /// Gets or sets the last opt-in date.
        /// </summary>
        [JsonPropertyName("lastOptinDate")]
        public DateTime LastOptInDate { get; set; }

        /// <summary>
        /// Gets or sets the last opt-out date.
        /// </summary>
        [JsonPropertyName("lastOptoutDate")]
        public DateTime LastOptoutDate { get; set; }

        /// <summary>
        /// Gets or sets the type of opt-in.
        /// </summary>
        [JsonPropertyName("optinType")]
        public string OptinType { get; set; }

        /// <summary>
        /// Gets or sets the type of opt-out.
        /// </summary>
        [JsonPropertyName("optoutType")]
        public string OptoutType { get; set; }

        /// <summary>
        /// Gets or sets the list of additional properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; }
    }
}
