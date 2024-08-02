using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to get information about a specific group.
    /// </summary>
    public class GetGroupRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }
    }
}
