using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response received after adding a subscriber.
    /// </summary>
    public class AddSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the new subscriber.
        /// </summary>
        [JsonPropertyName("subscriberId")]
        public string SubscriberId { get; set; }

        /// <summary>
        /// Gets or sets the status of the add operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }
}
