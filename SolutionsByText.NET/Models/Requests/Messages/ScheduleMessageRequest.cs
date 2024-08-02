using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages
{
    /// <summary>
    /// Represents the request payload for scheduling a message.
    /// This class contains the necessary information to schedule a message, including the sender, message content,
    /// schedule date and time, subscriber details, variables, reference ID, and media content.
    /// </summary>
    public class ScheduleMessageRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group to send the message to.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// The sender of the message.
        /// </summary>
        [JsonPropertyName("from")]
        public string? From { get; set; }

        /// <summary>
        /// The content of the message.
        /// </summary>
        [JsonPropertyName("message")]
        public required string Message { get; set; }

        /// <summary>
        /// The date and time when the message is scheduled to be sent.
        /// </summary>
        [JsonPropertyName("ScheduleDateTime")]
        public DateTime? ScheduleDateTime { get; set; }

        /// <summary>
        /// The list of subscribers to whom the message will be sent.
        /// </summary>
        [JsonPropertyName("subscribers")]
        public List<Subscriber>? Subscribers { get; set; }

        /// <summary>
        /// The list of variables to be used in the message.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<Variable>? Variables { get; set; }

        /// <summary>
        /// The reference ID associated with the message.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The media content (if any) to be included in the message.
        /// </summary>
        [JsonPropertyName("media")]
        public string? Media { get; set; }
    }
}