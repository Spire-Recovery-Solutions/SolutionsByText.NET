using SolutionsByText.NET.Models.Requests.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents a brand VBT message report response as specified by the API.
    /// </summary>
    public class BrandVbtMessageReportResponse
    {
        /// <summary>
        /// Gets or sets the subscriber information.
        /// </summary>
        [JsonPropertyName("subscriber")]
        public SubscriberResponseInbox? Subscriber { get; set; }

        /// <summary>
        /// Gets or sets the tracking ID number of the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string? MessageId { get; set; }

        /// <summary>
        /// Gets or sets the message status when the API was called.
        /// </summary>
        [JsonPropertyName("deliveryStatus")]
        public string? DeliveryStatus { get; set; }

        /// <summary>
        /// Gets or sets the message status code when the API was called.
        /// </summary>
        [JsonPropertyName("deliveryStatusCode")]
        public string? DeliveryStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the template ID (optional if templateName is provisioned).
        /// </summary>
        [JsonPropertyName("templateId")]
        public string? TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the message direction.
        /// </summary>
        [JsonPropertyName("direction")]
        public MessageType? Direction { get; set; }

        /// <summary>
        /// Gets or sets the customer-defined identifier for the message.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the Short Code or 10DLC used to send the message.
        /// </summary>
        [JsonPropertyName("communicationCode")]
        public string? CommunicationCode { get; set; }

        /// <summary>
        /// Gets or sets the time the message was sent from SBT.
        /// </summary>
        [JsonPropertyName("sentAt")]
        public string? SentAt { get; set; }

        /// <summary>
        /// Gets or sets the time the message was received by the handset.
        /// </summary>
        [JsonPropertyName("deliveredAt")]
        public string? DeliveredAt { get; set; }

        /// <summary>
        /// Gets or sets the time the message was received by the handset.
        /// </summary>
        [JsonPropertyName("receivedAt")]
        public string? ReceivedAt { get; set; }

        /// <summary>
        /// Gets or sets the time the message was read by the subscriber.
        /// </summary>
        [JsonPropertyName("readAt")]
        public string? ReadAt { get; set; }

        /// <summary>
        /// Gets or sets the user details.
        /// </summary>
        [JsonPropertyName("user")]
        public UserDetails? User { get; set; }

        /// <summary>
        /// Gets or sets the local time the message was sent from SBT (with timeZoneOffset).
        /// </summary>
        [JsonPropertyName("sentTimeLocal")]
        public string? SentTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the local time the message was delivered by the carrier (with timeZoneOffset).
        /// </summary>
        [JsonPropertyName("deliveredTimeLocal")]
        public string? DeliveredTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the local time the message was received by the handset (with timeZoneOffset).
        /// </summary>
        [JsonPropertyName("receivedTimeLocal")]
        public string? ReceivedTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the local time the message was read by the subscriber (with timeZoneOffset).
        /// </summary>
        [JsonPropertyName("readTimeLocal")]
        public string? ReadTimeLocal { get; set; }

        /// <summary>
        /// Gets or sets the subscriber custom parameters.
        /// </summary>
        [JsonPropertyName("subscriberCustomParams")]
        public List<SubscriberCustomParams>? SubscriberCustomParams { get; set; }
    }
}