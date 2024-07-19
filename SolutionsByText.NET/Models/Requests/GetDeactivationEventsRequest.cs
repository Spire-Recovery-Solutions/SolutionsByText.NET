using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to retrieve deactivation events.
    /// </summary>
    public class GetDeactivationEventsRequest
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

        /// <summary>
        /// Gets or sets the page number for pagination purposes.
        /// This is optional and can be null.
        /// </summary>
        [JsonPropertyName("pageNumber")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the size of the page for pagination purposes.
        /// This is optional and can be null.
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }
    }
}