using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.SmartUrl
{

    /// <summary>
    /// Represents a request to create a new SmartURL for a group.
    /// </summary>
    public class CreateSmartURLRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the long URL to be shortened.
        /// </summary>
        [JsonPropertyName("longUrl")]
        public string LongUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL suffix for the message.
        /// </summary>
        [JsonPropertyName("UrlSuffix")]
        public string? UrlSuffix { get; set; }

        /// <summary>
        /// Gets or sets the domain for the message.
        /// </summary>
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }
    }
}
