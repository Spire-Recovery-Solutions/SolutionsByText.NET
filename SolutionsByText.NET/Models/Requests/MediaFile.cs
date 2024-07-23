using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a media file associated with an inbound message.
    /// </summary>
    public class MediaFile
    {
        /// <summary>
        /// Gets or sets the unique identifier for the media file.
        /// </summary>
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the media file.
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}