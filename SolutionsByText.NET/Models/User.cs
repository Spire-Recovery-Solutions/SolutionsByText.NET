using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models
{
    /// Represents user information.
    /// </summary>
    public class User
    {
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("userId")]
        public string? UserId { get; set; }
    }
}
