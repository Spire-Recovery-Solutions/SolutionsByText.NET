using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{

    /// <summary>
    /// Represents a request to get carrier information for one or more phone numbers.
    /// </summary>
    public class GetPhoneNumberDataRequest
    {
        /// <summary>
        /// Gets or sets the list of phone numbers to look up.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public List<string> Msisdn { get; set; }
    }
}
