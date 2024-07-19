using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the structure of an error response from the API, providing details about the error.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the application code associated with the error response.
        /// </summary>
        [JsonPropertyName("appCode")]
        public string AppCode { get; set; }

        /// <summary>
        /// Gets or sets the message providing additional information about the error.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response indicates an error.
        /// </summary>
        [JsonPropertyName("isError")]
        public bool IsError { get; set; }
    }
}