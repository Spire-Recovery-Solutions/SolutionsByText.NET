using SolutionsByText.NET.Models.Responses;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to retrieve deactivation events.
    /// </summary>
    public class GetDeactivationEventsRequest : PaginationData
    {
        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        [JsonPropertyName("eventDate")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the event (e.g., "UserDeactivation").
        /// </summary>
        [JsonPropertyName("eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the country code where the event occurred (e.g., "US").
        /// </summary>
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
    }
}