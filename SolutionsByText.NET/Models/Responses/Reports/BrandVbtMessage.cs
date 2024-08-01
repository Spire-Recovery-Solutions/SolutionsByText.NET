using SolutionsByText.NET.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class BrandVbtMessage
    {
        /// <summary>
        /// Subscriber details.
        /// </summary>
        [JsonPropertyName("subscriber")]
        public Subscriber Subscriber { get; set; }

        /// <summary>
        /// Unique identifier for the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Delivery status of the message.
        /// </summary>
        [JsonPropertyName("deliveryStatus")]
        public string DeliveryStatus { get; set; }

        /// <summary>
        /// Delivery status code.
        /// </summary>
        [JsonPropertyName("deliveryStatusCode")]
        public string DeliveryStatusCode { get; set; }

        /// <summary>
        /// Message content.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Template identifier.
        /// </summary>
        [JsonPropertyName("templateId")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Direction of the message (e.g., "Inbound", "Outbound", "Both").
        /// </summary>
        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// Reference identifier for tracking.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        /// <summary>
        /// Communication code related to the message.
        /// </summary>
        [JsonPropertyName("communicationCode")]
        public string CommunicationCode { get; set; }

        /// <summary>
        /// Time the message was sent (UTC).
        /// </summary>
        [JsonPropertyName("sentAt")]
        public DateTime SentAt { get; set; }

        /// <summary>
        /// Time the message was delivered (UTC).
        /// </summary>
        [JsonPropertyName("deliveredAt")]
        public DateTime DeliveredAt { get; set; }

        /// <summary>
        /// Time the message was received (UTC).
        /// </summary>
        [JsonPropertyName("receivedAt")]
        public DateTime ReceivedAt { get; set; }

        /// <summary>
        /// Time the message was read (UTC).
        /// </summary>
        [JsonPropertyName("readAt")]
        public DateTime ReadAt { get; set; }

        /// <summary>
        /// User details related to the message.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// Sent time in local timezone.
        /// </summary>
        [JsonPropertyName("sentTimeLocal")]
        public DateTime SentTimeLocal { get; set; }

        /// <summary>
        /// Delivered time in local timezone.
        /// </summary>
        [JsonPropertyName("deliveredTimeLocal")]
        public DateTime DeliveredTimeLocal { get; set; }

        /// <summary>
        /// Received time in local timezone.
        /// </summary>
        [JsonPropertyName("receivedTimeLocal")]
        public DateTime ReceivedTimeLocal { get; set; }

        /// <summary>
        /// Read time in local timezone.
        /// </summary>
        [JsonPropertyName("readTimeLocal")]
        public DateTime ReadTimeLocal { get; set; }

        /// <summary>
        /// Media details associated with the message.
        /// </summary>
        [JsonPropertyName("mediaDetails")]
        public MediaDetails MediaDetails { get; set; }

        /// <summary>
        /// Total number of message segments.
        /// </summary>
        [JsonPropertyName("totalMessageSegments")]
        public int TotalMessageSegments { get; set; }

        /// <summary>
        /// Category of the message (e.g., promotional, transactional).
        /// </summary>
        [JsonPropertyName("messageCategory")]
        public string MessageCategory { get; set; }

        /// <summary>
        /// Mode of communication (e.g., SMS, Email).
        /// </summary>
        [JsonPropertyName("modeOfCommunication")]
        public string ModeOfCommunication { get; set; }

        /// <summary>
        /// Custom parameters for the subscriber.
        /// </summary>
        [JsonPropertyName("subscriberCustomParams")]
        public List<CustomParam> SubscriberCustomParams { get; set; }
    }
}
