using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.SmartUrl
{
    /// <summary>
    /// Represents the request payload for shortening a long URL.
    /// This class contains the long URL to be shortened.
    /// </summary>
    public class UpdateSmartURLRequest
    {
        /// <summary>
        /// Gets or sets the group ID.
        /// This parameter is required.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the short URL.
        /// This parameter is required and should be URL encoded.
        /// </summary>
        [JsonIgnore]
        public string ShortUrl { get; set; } = string.Empty;

        /// <summary>
        /// The long URL to be shortened.
        /// </summary>
        [JsonPropertyName("longUrl")]
        public required string LongUrl { get; set; }
    }
}
