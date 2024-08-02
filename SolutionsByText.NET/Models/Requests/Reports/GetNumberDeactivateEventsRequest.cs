using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class GetNumberDeactivateEventsRequest : PaginationData
    {
        /// <summary>
        /// The group ID of the subscriber.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// The mobile number of the subscriber (msisdn).
        /// </summary>
        [JsonPropertyName("msisdn")]
        public required string Msisdn { get; set; }

        /// <summary>
        /// The start date for the request.
        /// </summary>
        [JsonPropertyName("fromDate")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// The end date for the request.
        /// </summary>
        [JsonPropertyName("toDate")]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// The country code of the subscriber.
        /// </summary>
        [JsonPropertyName("countryCode")]
        public required string CountryCode { get; set; }
    }
}
