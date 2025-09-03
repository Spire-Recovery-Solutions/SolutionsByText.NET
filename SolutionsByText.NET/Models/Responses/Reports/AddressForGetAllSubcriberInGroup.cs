using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents address information for the Get All Subscribers In Group response.
    /// </summary>
    public class AddressForGetAllSubcriberInGroup
    {
        /// <summary>
        /// Primary address line.
        /// </summary>
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        /// <summary>
        /// Secondary address line (apartment, suite, etc.).
        /// </summary>
        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// State or province.
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; }

        /// <summary>
        /// Postal code or ZIP code.
        /// </summary>
        [JsonPropertyName("postalCode")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }
    }
}