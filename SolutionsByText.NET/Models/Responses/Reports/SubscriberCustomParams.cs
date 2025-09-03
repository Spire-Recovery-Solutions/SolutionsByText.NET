using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents subscriber custom parameters as specified by the API.
    /// </summary>
    public class SubscriberCustomParams
    {
        /// <summary>
        /// Gets or sets the parameter name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}