using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents a property associated with a consent item.
    /// </summary>
    public class ConsentProperty
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the property.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}