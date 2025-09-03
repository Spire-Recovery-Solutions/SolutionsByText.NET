using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.PhoneNumbers
{
    /// <summary>
    /// Represents carrier information for a phone number.
    /// </summary>
    public class CarrierInfo
    {
        /// <summary>
        /// Gets or sets the wireless provider ID for the subscriber's carrier.
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the wireless provider name for the subscriber's carrier.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

}
