namespace SolutionsByText.NET.Models.Responses;

using System.Text.Json.Serialization;


    /// <summary>
    /// Represents the response received after sending a message.
    /// </summary>
    public class SendMessageResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the sent message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the status of the sent message.
        /// </summary>
        [JsonPropertyName("status")]
        public MessageStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after sending a template message.
    /// </summary>
    public class SendTemplateMessageResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the sent message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the status of the sent message.
        /// </summary>
        [JsonPropertyName("status")]
        public MessageStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after scheduling a message.
    /// </summary>
    public class ScheduleMessageResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the scheduled message.
        /// </summary>
        [JsonPropertyName("scheduleId")]
        public string ScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the status of the scheduled message.
        /// </summary>
        [JsonPropertyName("status")]
        public ScheduleStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after requesting subscriber status.
    /// </summary>
    public class GetSubscriberStatusResponse
    {
        /// <summary>
        /// Gets or sets the list of subscriber statuses.
        /// </summary>
        [JsonPropertyName("subscribers")]
        public List<SubscriberStatus> Subscribers { get; set; }
    }

    /// <summary>
    /// Represents the status of a single subscriber.
    /// </summary>
    public class SubscriberStatus
    {
        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the status of the subscriber.
        /// </summary>
        [JsonPropertyName("status")]
        public SubscriptionStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after adding a subscriber.
    /// </summary>
    public class AddSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the new subscriber.
        /// </summary>
        [JsonPropertyName("subscriberId")]
        public string SubscriberId { get; set; }

        /// <summary>
        /// Gets or sets the status of the add operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after confirming a subscriber.
    /// </summary>
    public class ConfirmSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the status of the confirmation operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after deleting a subscriber.
    /// </summary>
    public class DeleteSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the status of the delete operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after requesting group information.
    /// </summary>
    public class GetGroupResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Represents the response received after requesting outbound messages.
    /// </summary>
    public class GetOutboundMessagesResponse
    {
        /// <summary>
        /// Gets or sets the list of outbound messages.
        /// </summary>
        [JsonPropertyName("messages")]
        public List<OutboundMessage> Messages { get; set; }
    }

    /// <summary>
    /// Represents a single outbound message.
    /// </summary>
    public class OutboundMessage
    {
        /// <summary>
        /// Gets or sets the unique identifier of the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the status of the message.
        /// </summary>
        [JsonPropertyName("status")]
        public MessageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was sent.
        /// </summary>
        [JsonPropertyName("sentDateTime")]
        public DateTime SentDateTime { get; set; }
    }

    /// <summary>
    /// Represents the response received after requesting inbound messages.
    /// </summary>
    public class GetInboundMessagesResponse
    {
        /// <summary>
        /// Gets or sets the list of inbound messages.
        /// </summary>
        [JsonPropertyName("messages")]
        public List<InboundMessage> Messages { get; set; }
    }

    /// <summary>
    /// Represents a single inbound message.
    /// </summary>
    public class InboundMessage
    {
        /// <summary>
        /// Gets or sets the unique identifier of the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the sender.
        /// </summary>
        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was received.
        /// </summary>
        [JsonPropertyName("receivedDateTime")]
        public DateTime ReceivedDateTime { get; set; }
    }

    /// <summary>
    /// Represents the response received after creating a SmartURL.
    /// </summary>
    public class CreateSmartURLResponse
    {
        /// <summary>
        /// Gets or sets the shortened URL.
        /// </summary>
        [JsonPropertyName("shortUrl")]
        public string ShortUrl { get; set; }
    }

    /// <summary>
    /// Represents the response received after requesting phone number data.
    /// </summary>
    public class GetPhoneNumberDataResponse
    {
        /// <summary>
        /// Gets or sets the list of phone number data.
        /// </summary>
        [JsonPropertyName("phoneNumbers")]
        public List<PhoneNumberData> PhoneNumbers { get; set; }
    }

    /// <summary>
    /// Represents data for a single phone number.
    /// </summary>
    public class PhoneNumberData
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the carrier information.
        /// </summary>
        [JsonPropertyName("carrier")]
        public CarrierInfo Carrier { get; set; }
    }

    /// <summary>
    /// Represents carrier information for a phone number.
    /// </summary>
    public class CarrierInfo
    {
        /// <summary>
        /// Gets or sets the name of the carrier.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the carrier.
        /// </summary>
        [JsonPropertyName("type")]
        public CarrierType Type { get; set; }
    }

    /// <summary>
    /// Represents the response received after adding a brand subscriber.
    /// </summary>
    public class AddBrandSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the new subscriber.
        /// </summary>
        [JsonPropertyName("subscriberId")]
        public string SubscriberId { get; set; }

        /// <summary>
        /// Gets or sets the status of the add operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }

    /// <summary>
    /// Represents the response received after confirming a brand subscriber.
    /// </summary>
    public class ConfirmBrandSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the status of the confirmation operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }
    /// <summary>
    /// Defines the possible statuses of a message.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageStatus
    {
        /// <summary>
        /// The message has been queued for sending.
        /// </summary>
        Queued,

        /// <summary>
        /// The message has been sent to the carrier.
        /// </summary>
        Sent,

        /// <summary>
        /// The message has been delivered to the recipient's device.
        /// </summary>
        Delivered,

        /// <summary>
        /// The message failed to be delivered.
        /// </summary>
        Failed
    }

    /// <summary>
    /// Defines the possible statuses of a scheduled message.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ScheduleStatus
    {
        /// <summary>
        /// The message has been successfully scheduled.
        /// </summary>
        Scheduled,

        /// <summary>
        /// The scheduling of the message failed.
        /// </summary>
        Failed
    }

    /// <summary>
    /// Defines the possible statuses of a subscriber's subscription.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionStatus
    {
        /// <summary>
        /// The subscriber is active and can receive messages.
        /// </summary>
        Active,

        /// <summary>
        /// The subscriber is inactive and cannot receive messages.
        /// </summary>
        Inactive,

        /// <summary>
        /// The subscriber is not found in the system.
        /// </summary>
        NotFound
    }

    /// <summary>
    /// Defines the possible statuses of an operation.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OperationStatus
    {
        /// <summary>
        /// The operation was successful.
        /// </summary>
        Success,

        /// <summary>
        /// The operation failed.
        /// </summary>
        Failure
    }
    