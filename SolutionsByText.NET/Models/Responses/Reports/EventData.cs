using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents an individual event data in the JSON response.
    /// This class contains information about the event, including the user details,
    /// carrier information, and custom parameters.
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// The unique identifier of the event.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The first name of the user associated with the event.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// The last name of the user associated with the event.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// The country code of the user associated with the event.
        /// </summary>
        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// The mobile number (MSISDN) of the user associated with the event.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }

        /// <summary>
        /// The dialing code of the user associated with the event.
        /// </summary>
        [JsonPropertyName("dialingCode")]
        public string? DialingCode { get; set; }

        /// <summary>
        /// The identifier of the old carrier associated with the event.
        /// </summary>
        [JsonPropertyName("oldCarrierId")]
        public string? OldCarrierId { get; set; }

        /// <summary>
        /// The name of the old carrier associated with the event.
        /// </summary>
        [JsonPropertyName("oldCarrierName")]
        public string? OldCarrierName { get; set; }

        /// <summary>
        /// The identifier of the new carrier associated with the event.
        /// </summary>
        [JsonPropertyName("newCarrierId")]
        public string? NewCarrierId { get; set; }

        /// <summary>
        /// The name of the new carrier associated with the event.
        /// </summary>
        [JsonPropertyName("newCarrierName")]
        public string? NewCarrierName { get; set; }

        /// <summary>
        /// The mobile status associated with the event.
        /// </summary>
        [JsonPropertyName("mobileStatus")]
        public string? MobileStatus { get; set; }

        /// <summary>
        /// The type of the event.
        /// </summary>
        [JsonPropertyName("eventType")]
        public string? EventType { get; set; }

        /// <summary>
        /// The date and time of the event.
        /// </summary>
        [JsonPropertyName("eventDate")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// The list of custom parameters associated with the event.
        /// </summary>
        [JsonPropertyName("customParams")]
        public List<CustomParam>? CustomParams { get; set; }
    }
}