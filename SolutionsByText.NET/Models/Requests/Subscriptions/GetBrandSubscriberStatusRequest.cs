using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscription
{
    public class GetBrandSubscriberStatusRequest
    {
        /// <summary>
        /// The unique identifier for the brand.
        /// </summary>
        [JsonPropertyName("brandId")]
        public string BrandId { get; set; }

        /// <summary>
        /// Mobile number with dialing code (11 digits with no +; ex: 1##########).
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }
    }
}
