using SolutionsByText.NET.Models.Responses.Enums;
using SolutionsByText.NET.Models.Responses.Reports;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    /// <summary>
    /// Represents a single outbound/inbound message.
    /// </summary>
    public class WebhookMessage
    {
        /// <summary>
        /// Gets or sets the subscriber information.
        /// </summary>
        [JsonPropertyName("subscriber")]
        public Subscriber Subscriber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the delivery status of the message.
        /// </summary>
        [JsonPropertyName("deliveryStatus")]
        public string DeliveryStatus { get; set; }

        /// <summary>
        /// Gets or sets the delivery status code of the message.
        /// </summary>
        [JsonPropertyName("deliveryStatusCode")]
        public string DeliveryStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the template identifier used for the message.
        /// </summary>
        [JsonPropertyName("templateId")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the direction of the message.
        /// </summary>
        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets the reference ID for tracking the message.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the communication code associated with the message.
        /// </summary>
        [JsonPropertyName("communicationCode")]
        public string CommunicationCode { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was sent.
        /// </summary>
        [JsonPropertyName("sentAt")]
        public DateTime SentAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was delivered.
        /// </summary>
        [JsonPropertyName("deliveredAt")]
        public DateTime DeliveredAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was received.
        /// </summary>
        [JsonPropertyName("receivedAt")]
        public DateTime ReceivedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was read.
        /// </summary>
        [JsonPropertyName("readAt")]
        public DateTime ReadAt { get; set; }

        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the local time when the message was sent.
        /// </summary>
        [JsonPropertyName("sentTimeLocal")]
        public DateTime SentTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the local time when the message was delivered.
        /// </summary>
        [JsonPropertyName("deliveredTimeLocal")]
        public DateTime DeliveredTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the local time when the message was received.
        /// </summary>
        [JsonPropertyName("receivedTimeLocal")]
        public DateTime ReceivedTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the local time when the message was read.
        /// </summary>
        [JsonPropertyName("readTimeLocal")]
        public DateTime ReadTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the media details associated with the message.
        /// </summary>
        [JsonPropertyName("mediaDetails")]
        public MediaDetails MediaDetails { get; set; }

        /// <summary>
        /// Gets or sets the total number of message segments.
        /// </summary>
        [JsonPropertyName("totalMessageSegments")]
        public int TotalMessageSegments { get; set; }

        /// <summary>
        /// Gets or sets the mode of communication used.
        /// </summary>
        [JsonPropertyName("modeOfCommunication")]
        public string ModeOfCommunication { get; set; }

        /// <summary>
        /// Gets or sets the custom parameters for the subscriber.
        /// </summary>
        [JsonPropertyName("subscriberCustomParams")]
        public List<CustomParam> SubscriberCustomParams { get; set; }
    }

}