using SolutionsByText.NET.Models.Responses;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    /// <summary>
    /// Represents a request to retrieve deactivation events.
    /// </summary>
    public class GetDeactivationEventsRequest : PaginationData
    {
        /// <summary>
        /// Gets or sets the date of the event. Date to be checked for events.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset EventDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the event. The event type can be "Deactivated" or "Ported".
        /// </summary>
        [JsonIgnore]
        public string EventType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the country code where the event occurred. Country Code is not required to retrieve deact events for US numbers. Currently, SBT only has deact data for US numbers.
        /// </summary>
        [JsonIgnore]
        public string? CountryCode { get; set; }
    }
}