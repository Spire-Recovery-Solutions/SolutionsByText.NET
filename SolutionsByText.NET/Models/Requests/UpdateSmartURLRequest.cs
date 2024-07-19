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
        /// The long URL to be shortened.
        /// </summary>
        [JsonPropertyName("longUrl")]
        public string LongUrl { get; set; }
    }
}
