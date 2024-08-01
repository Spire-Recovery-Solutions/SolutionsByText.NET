using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents a custom parameter with a name and value.
    /// This class is used to deserialize and serialize the "customParams" array
    /// within the EventData object in the JSON response.
    /// </summary>
    public class CustomParam
    {
        /// <summary>
        /// The name of the custom parameter.
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The value of the custom parameter.
        /// </summary>
        [JsonPropertyName("Value")]
        public string Value { get; set; }
    }
}