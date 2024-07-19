using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response received after requesting group information.
    /// </summary>
    public class GetGroupResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
