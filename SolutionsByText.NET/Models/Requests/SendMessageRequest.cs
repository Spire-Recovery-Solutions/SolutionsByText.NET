using SolutionsByText.NET.Models.Requests.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to send a message to one or more subscribers in a group.
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group to send the message to.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the content of the message to be sent.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the type of message being sent (e.g., broadcast, unicast, multicast).
        /// </summary>
        [JsonPropertyName("messageType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets the list of subscribers to receive the message.
        /// </summary>
        [JsonPropertyName("subscribers")]
        public List<Subscriber> Subscribers { get; set; }
    }
}
