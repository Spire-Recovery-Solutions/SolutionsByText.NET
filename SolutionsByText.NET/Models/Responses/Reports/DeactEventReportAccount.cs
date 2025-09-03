using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents a deactivation event report for an account, matching the API specification exactly.
    /// </summary>
    public class DeactEventReportAccount
    {
        /// <summary>
        /// Gets or sets the first name of the subscriber.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the subscriber.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the country code of the subscriber.
        /// </summary>
        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the mobile number (MSISDN) of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the dialing code of the subscriber.
        /// </summary>
        [JsonPropertyName("dialingCode")]
        public string? DialingCode { get; set; }

        /// <summary>
        /// Gets or sets the SBT platform code for the subscriber's previous carrier.
        /// </summary>
        [JsonPropertyName("oldCarrierId")]
        public string? OldCarrierId { get; set; }

        /// <summary>
        /// Gets or sets the name of subscriber's previous carrier.
        /// </summary>
        [JsonPropertyName("oldCarrierName")]
        public string? OldCarrierName { get; set; }

        /// <summary>
        /// Gets or sets the SBT platform code for the subscriber's new/current carrier.
        /// </summary>
        [JsonPropertyName("newCarrierId")]
        public string? NewCarrierId { get; set; }

        /// <summary>
        /// Gets or sets the name of subscriber's new/current carrier.
        /// </summary>
        [JsonPropertyName("newCarrierName")]
        public string? NewCarrierName { get; set; }

        /// <summary>
        /// Gets or sets the mobile status of the subscriber.
        /// </summary>
        [JsonPropertyName("mobileStatus")]
        public string? MobileStatus { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        [JsonPropertyName("eventType")]
        public string? EventType { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the event.
        /// </summary>
        [JsonPropertyName("eventDate")]
        public DateTime? EventDate { get; set; }
    }
}