using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents relationship information for the Get All Subscribers In Group response.
    /// </summary>
    public class RelationForGetAllSubcriberInGroup
    {
        /// <summary>
        /// Name of the related person.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The relationship to the subscriber.
        /// </summary>
        [JsonPropertyName("relationship")]
        public string? Relationship { get; set; }
    }
}