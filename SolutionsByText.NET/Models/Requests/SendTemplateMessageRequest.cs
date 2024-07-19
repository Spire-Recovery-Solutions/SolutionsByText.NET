using SolutionsByText.NET.Models.Requests.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to send a template message to one or more subscribers in a group.
    /// </summary>
    public class SendTemplateMessageRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group to send the message to.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the template to use.
        /// </summary>
        [JsonPropertyName("templateId")]
        public string TemplateId { get; set; }

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

        /// <summary>
        /// Gets or sets the variables to be used in the template.
        /// </summary>
        [JsonPropertyName("variables")]
        public Dictionary<string, string> Variables { get; set; }
    }
}
