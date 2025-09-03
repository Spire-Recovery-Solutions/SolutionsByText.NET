using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscriptions
{
    /// <summary>
    /// Represents a request to delete a subscriber from a group.
    /// </summary>
    public class DeleteSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the subscriber to delete.
        /// </summary>
        [JsonIgnore]
        public string Msisdn { get; set; } = string.Empty;
    }
}
