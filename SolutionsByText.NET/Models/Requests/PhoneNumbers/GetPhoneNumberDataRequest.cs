using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.PhoneNumbers
{

    /// <summary>
    /// Represents a request to get carrier information for one or more phone numbers.
    /// </summary>
    public class GetPhoneNumberDataRequest
    {
        /// <summary>
        /// Mobile numbers with dialing code. Eleven digits with no plus sign (12345678902).
        /// </summary>
        [JsonIgnore]
        public required List<string> Msisdn { get; set; }

        /// <summary>
        /// Carrier specifier.
        /// </summary>
        [JsonIgnore]
        public string? Includes { get; set; }
    }
}
