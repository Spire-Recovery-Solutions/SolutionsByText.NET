using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{

    /// <summary>
    /// Represents the response received after requesting phone number data.
    /// </summary>
    public class GetPhoneNumberDataResponse
    {
        /// <summary>
        /// Gets or sets the list of phone number data.
        /// </summary>
        [JsonPropertyName("phoneNumbers")]
        public List<PhoneNumberData> PhoneNumbers { get; set; }
    }
}
