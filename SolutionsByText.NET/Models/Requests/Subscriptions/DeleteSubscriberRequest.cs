using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscription
{
    /// <summary>
    /// Represents a request to delete a subscriber from a group.
    /// </summary>
    public class DeleteSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber to delete.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public required string Msisdn { get; set; }
    }
}
