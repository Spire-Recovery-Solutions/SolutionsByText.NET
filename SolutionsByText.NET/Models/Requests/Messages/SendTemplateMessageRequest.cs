using SolutionsByText.NET.Models.Requests.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages
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
        public required string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the template to use.
        /// </summary>
        [JsonPropertyName("templateId")]
        public required string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the name of the template to use (if templateId is not provided).
        /// </summary>
        [JsonPropertyName("templateName")]
        public string? TemplateName { get; set; }

        /// <summary>
        /// Gets or sets the type of message being sent (e.g., broadcast, unicast, multicast).
        /// </summary>
        [JsonPropertyName("messageType")]
        [JsonConverter(typeof(JsonStringEnumConverter<MessageType>))]
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier for tracking.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the list of variables to be used in the template.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<Variable>? Variables { get; set; }

        /// <summary>
        /// Gets or sets the list of subscribers to receive the message.
        /// </summary>
        [JsonPropertyName("subscribers")]
        public List<Subscriber>? Subscribers { get; set; }

        /// <summary>
        /// Gets or sets the media file in base64 Data URI format or a fully qualified URL.
        /// </summary>
        [JsonPropertyName("media")]
        public string? Media { get; set; }

    }
}
