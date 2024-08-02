using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages
{
    /// <summary>
    /// Represents the request payload for scheduling a template message.
    /// This class contains the necessary information to schedule a message using a pre-defined template, including the template ID and name,
    /// schedule date and time, subscriber details, variables, reference ID, and media content.
    /// </summary>
    public class ScheduleTemplateMessageRequest
    {
        /// <summary>
        /// The ID of the template to be used for the message.
        /// This parameter is optional if templateName is provisioned.
        /// </summary>
        [JsonPropertyName("templateId")]
        public required string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the brand.
        /// This parameter is required.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// The name of the template to be used for the message.
        /// This parameter is considered only when templateId is not provided.
        /// </summary>
        [JsonPropertyName("templateName")]
        public string? TemplateName { get; set; }

        /// <summary>
        /// The date and time when the message is scheduled to be sent.
        /// </summary>
        [JsonPropertyName("scheduleDateTime")]
        public DateTime? ScheduleDateTime { get; set; }

        /// <summary>
        /// The list of subscribers to whom the message will be sent.
        /// This can be null if no subscribers are provided.
        /// </summary>
        [JsonPropertyName("subscribers")]
        public List<Subscriber>? Subscribers { get; set; }

        /// <summary>
        /// The list of variables to be used in the message.
        /// This can be null if no variables are provided.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<Variable>? Variables { get; set; }

        /// <summary>
        /// The reference ID associated with the message.
        /// This can be null if no reference ID is provided.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The media content (if any) to be included in the message.
        /// This can be null if no media is provided.
        /// </summary>
        [JsonPropertyName("media")]
        public string? Media { get; set; }
    }
}
