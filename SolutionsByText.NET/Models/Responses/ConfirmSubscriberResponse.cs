using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{

    /// <summary>
    /// Represents the response received after confirming a subscriber.
    /// </summary>
    public class ConfirmSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the status of the confirmation operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }
}
