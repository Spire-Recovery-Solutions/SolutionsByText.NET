using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents subscriber response inbox information as specified by the API.
    /// </summary>
    public class SubscriberResponseInbox
    {
        /// <summary>
        /// Gets or sets the subscriber's last name.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the subscriber's first name.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the mobile number with dialing code. Eleven digits with no plus sign.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }
    }
}