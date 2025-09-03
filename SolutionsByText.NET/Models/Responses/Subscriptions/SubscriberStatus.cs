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
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the name of the carrier.
        /// </summary>
        [JsonPropertyName("carrierName")]
        public string? CarrierName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the carrier.
        /// </summary>
        [JsonPropertyName("carrierId")]
        public string? CarrierId { get; set; }

        /// <summary>
        /// First Date the subscriber was opted into messaging.
        /// </summary>
        [JsonPropertyName("firstOptInDate")]
        public string? FirstOptInDate { get; set; }

        /// <summary>
        /// Last Date the subscriber was opted into messaging.
        /// </summary>
        [JsonPropertyName("lastOptinDate")]
        public string? LastOptinDate { get; set; }

        /// <summary>
        /// Date the subscriber was opted out of messaging.
        /// </summary>
        [JsonPropertyName("lastOptoutDate")]
        public string? LastOptoutDate { get; set; }

        /// <summary>
        /// Method by which the subscriber was opted into messaging.
        /// </summary>
        [JsonPropertyName("optinType")]
        public string? OptinType { get; set; }

        /// <summary>
        /// Method by which the subscriber was opted out of messaging. Will show the keyword if that method was used.
        /// </summary>
        [JsonPropertyName("optoutType")]
        public string? OptoutType { get; set; }

        /// <summary>
        /// Gets or sets the list of additional properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public List<Property>? Properties { get; set; }
    }
}
