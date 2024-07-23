using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
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
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the short URL.
        /// This parameter is required and should be URL encoded.
        /// </summary>
        [JsonPropertyName("shortUrl")]
        public string ShortUrl { get; set; }

        /// <summary>
        /// The long URL to be shortened.
        /// </summary>
        [JsonPropertyName("longUrl")]
        public string LongUrl { get; set; }
    }
}
