using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents custom properties for the Get All Subscribers In Group response.
    /// </summary>
    public class PropertiesForGetAllSubcriberInGroup
    {
        /// <summary>
        /// Customer-defined variable name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Customer-defined variable value.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}