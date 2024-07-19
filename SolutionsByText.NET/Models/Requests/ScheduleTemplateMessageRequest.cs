using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
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
        /// </summary>
        [JsonPropertyName("templateId")]
        public string TemplateId { get; set; }

        /// <summary>
        /// The name of the template to be used for the message.
        /// </summary>
        [JsonPropertyName("templateName")]
        public string TemplateName { get; set; }

        /// <summary>
        /// The date and time when the message is scheduled to be sent.
        /// </summary>
        [JsonPropertyName("ScheduleDateTime")]
        public DateTime ScheduleDateTime { get; set; }

        /// <summary>
        /// The list of subscribers to whom the message will be sent.
        /// </summary>
        [JsonPropertyName("subscribers")]
        public List<Subscriber> Subscribers { get; set; }

        /// <summary>
        /// The list of variables to be used in the message.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<Variable> Variables { get; set; }

        /// <summary>
        /// The reference ID associated with the message.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        /// <summary>
        /// The media content (if any) to be included in the message.
        /// </summary>
        [JsonPropertyName("media")]
        public string Media { get; set; }
    }
}