using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests;

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

/// <summary>
/// Represents a request to schedule a message for future delivery.
/// </summary>
public class ScheduleMessageRequest
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
    /// Gets or sets the date and time when the message should be sent.
    /// </summary>
    [JsonPropertyName("scheduleDateTime")]
    public DateTime ScheduleDateTime { get; set; }

    /// <summary>
    /// Gets or sets the list of subscribers to receive the message.
    /// </summary>
    [JsonPropertyName("subscribers")]
    public List<Subscriber> Subscribers { get; set; }
}

/// <summary>
/// Represents a request to get the status of one or more subscribers in a group.
/// </summary>
public class GetSubscriberStatusRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the list of phone numbers to check the status for.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public List<string> Msisdn { get; set; }
}

/// <summary>
/// Represents a request to add a new subscriber to a group.
/// </summary>
public class AddSubscriberRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group to add the subscriber to.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the subscriber.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }

    /// <summary>
    /// Gets or sets the first name of the subscriber.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the subscriber.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email of the subscriber.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }
}

/// <summary>
/// Represents a request to confirm a subscriber's opt-in using a PIN.
/// </summary>
public class ConfirmSubscriberRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the subscriber.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }

    /// <summary>
    /// Gets or sets the PIN provided by the subscriber.
    /// </summary>
    [JsonPropertyName("pin")]
    public string Pin { get; set; }
}

/// <summary>
/// Represents a request to delete a subscriber from a group.
/// </summary>
public class DeleteSubscriberRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the subscriber to delete.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }
}

/// <summary>
/// Represents a request to get information about a specific group.
/// </summary>
public class GetGroupRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }
}

/// <summary>
/// Represents a request to get details of outbound messages for a specific group.
/// </summary>
public class GetOutboundMessagesRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the start date for the report.
    /// </summary>
    [JsonPropertyName("fromDate")]
    public DateTime FromDate { get; set; }

    /// <summary>
    /// Gets or sets the end date for the report.
    /// </summary>
    [JsonPropertyName("toDate")]
    public DateTime ToDate { get; set; }
}

/// <summary>
/// Represents a request to get details of inbound messages for a specific group.
/// </summary>
public class GetInboundMessagesRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the start date for the report.
    /// </summary>
    [JsonPropertyName("fromDate")]
    public DateTime FromDate { get; set; }

    /// <summary>
    /// Gets or sets the end date for the report.
    /// </summary>
    [JsonPropertyName("toDate")]
    public DateTime ToDate { get; set; }
}

/// <summary>
/// Represents a request to create a new SmartURL for a group.
/// </summary>
public class CreateSmartURLRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the long URL to be shortened.
    /// </summary>
    [JsonPropertyName("longUrl")]
    public string LongUrl { get; set; }
}

/// <summary>
/// Represents a request to get carrier information for one or more phone numbers.
/// </summary>
public class GetPhoneNumberDataRequest
{
    /// <summary>
    /// Gets or sets the list of phone numbers to look up.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public List<string> Msisdn { get; set; }
}

/// <summary>
/// Represents a request to add a new subscriber to a brand.
/// </summary>
public class AddBrandSubscriberRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the brand.
    /// </summary>
    [JsonPropertyName("brandId")]
    public string BrandId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the subscriber.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }

    /// <summary>
    /// Gets or sets the first name of the subscriber.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the subscriber.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email of the subscriber.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }
}

/// <summary>
/// Represents a request to confirm a subscriber's opt-in for a brand using a PIN.
/// </summary>
public class ConfirmBrandSubscriberRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the brand.
    /// </summary>
    [JsonPropertyName("brandId")]
    public string BrandId { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the subscriber.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }

    /// <summary>
    /// Gets or sets the PIN provided by the subscriber.
    /// </summary>
    [JsonPropertyName("pin")]
    public string Pin { get; set; }
}

/// <summary>
/// Defines the types of messages that can be sent through the Solutions By Text system.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageType
{
    /// <summary>
    /// A message sent to all subscribers in a group.
    /// </summary>
    BroadcastMessage,

    /// <summary>
    /// A message sent to a single subscriber.
    /// </summary>
    Unicast,

    /// <summary>
    /// A message sent to multiple, but not all, subscribers in a group.
    /// </summary>
    Multicast
}

/// <summary>
/// Defines the types of verification that can be used for subscriber opt-in.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VerificationType
{
    /// <summary>
    /// Verification using a PIN sent to the subscriber.
    /// </summary>
    Pin,

    /// <summary>
    /// Verification using a keyword response from the subscriber.
    /// </summary>
    ReservedWord,

    /// <summary>
    /// Opt-in without explicit verification (may be subject to regulatory restrictions).
    /// </summary>
    SilentOptin,

    /// <summary>
    /// Standard opt-in process.
    /// </summary>
    Optin
}

/// <summary>
/// Defines the types of events that can trigger a deactivation report.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DeactivationEventType
{
    /// <summary>
    /// The phone number has been deactivated.
    /// </summary>
    Deactivated,

    /// <summary>
    /// The phone number has been ported to a different carrier.
    /// </summary>
    Ported,

    /// <summary>
    /// The phone number has been reassigned.
    /// </summary>
    Reassigned
}

/// <summary>
/// Defines the types of messages that can be included in message reports.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageReportType
{
    /// <summary>
    /// All types of messages.
    /// </summary>
    All,

    /// <summary>
    /// Only two-way conversation messages.
    /// </summary>
    Twoway,

    /// <summary>
    /// Only opt-in response messages.
    /// </summary>
    OptInResponse,

    /// <summary>
    /// Only keyword response messages.
    /// </summary>
    KeywordResponse,

    /// <summary>
    /// Only automated response messages.
    /// </summary>
    AutoResponse,

    /// <summary>
    /// Only broadcast messages.
    /// </summary>
    Broadcast,

    /// <summary>
    /// Only scheduled broadcast messages.
    /// </summary>
    ScheduledBroadcast,

    /// <summary>
    /// Only stop response messages.
    /// </summary>
    StopResponse,

    /// <summary>
    /// Only help response messages.
    /// </summary>
    HelpResponse
}

/// <summary>
/// Defines the types of carriers that can be returned in phone number lookups.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CarrierType
{
    /// <summary>
    /// A major wireless carrier.
    /// </summary>
    Wireless,

    /// <summary>
    /// A landline carrier.
    /// </summary>
    Landline,

    /// <summary>
    /// A voice over IP carrier.
    /// </summary>
    VoIP,

    /// <summary>
    /// An unknown type of carrier.
    /// </summary>
    Unknown
}