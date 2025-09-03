using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents user details information as specified by the API.
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the internal ID number of the sending user.
        /// </summary>
        [JsonPropertyName("userId")]
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the email address of the sending user.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}