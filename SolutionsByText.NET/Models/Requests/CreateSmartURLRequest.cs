using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
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
    }
}
