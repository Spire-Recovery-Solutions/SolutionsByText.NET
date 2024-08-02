using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.PhoneNumbers
{
    /// <summary>
    /// Represents data for a single phone number.
    /// </summary>
    public class PhoneNumberData
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the carrier information.
        /// </summary>
        [JsonPropertyName("carrier")]
        public CarrierInfo? Carrier { get; set; }
    }
}
