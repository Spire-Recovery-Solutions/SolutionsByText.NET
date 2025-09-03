using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscriptions
{
    public class GetBrandSubscriberStatusRequest
    {
        /// <summary>
        /// The unique identifier for the brand.
        /// </summary>
        [JsonIgnore]
        public string BrandId { get; set; } = string.Empty;

        /// <summary>
        /// Mobile number with dialing code (11 digits with no +; ex: 1##########).
        /// </summary>
        [JsonIgnore]
        public string? Msisdn { get; set; }
    }
}
