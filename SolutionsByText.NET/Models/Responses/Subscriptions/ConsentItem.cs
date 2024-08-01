using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Subscriptions
{
    /// <summary>
    /// Represents a consent item with its associated details.
    /// </summary>
    public class ConsentItem
    {
        /// <summary>
        /// Gets or sets the consent category.
        /// </summary>
        [JsonPropertyName("consentCategory")]
        public string ConsentCategory { get; set; }

        /// <summary>
        /// Gets or sets the group IDs associated with the consent item.
        /// </summary>
        [JsonPropertyName("groupIds")]
        public List<string> GroupIds { get; set; }

        /// <summary>
        /// Gets or sets the status of the consent item.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the mobile subscriber number.
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
        /// Gets or sets the date and time of the first opt-in.
        /// </summary>
        [JsonPropertyName("firstOptInDate")]
        public DateTime FirstOptInDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the last opt-in.
        /// </summary>
        [JsonPropertyName("lastOptinDate")]
        public DateTime LastOptinDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the last opt-out.
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
        /// Gets or sets the properties associated with the consent item.
        /// </summary>
        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; }
    }
}