using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class GetNumberDeactivateEventsRequest : PaginationData
    {
        /// <summary>
        /// The group ID of the subscriber.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// The mobile number of the subscriber (msisdn).
        /// </summary>
        [JsonIgnore]
        public string Msisdn { get; set; } = string.Empty;

        /// <summary>
        /// The start date for the request.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? FromDate { get; set; }

        /// <summary>
        /// The end date for the request.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? ToDate { get; set; }

        /// <summary>
        /// The country code of the subscriber.
        /// </summary>
        [JsonIgnore]
        public string CountryCode { get; set; } = string.Empty;
    }
}
