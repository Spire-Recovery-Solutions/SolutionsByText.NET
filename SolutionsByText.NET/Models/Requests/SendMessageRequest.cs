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
/// Represents a subscriber in the Solutions By Text system.
/// </summary>
public class Subscriber
{
    /// <summary>
    /// Gets or sets the Mobile Station International Subscriber Directory Number (MSISDN) of the subscriber.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }
}

/// <summary>
/// Defines the types of messages that can be sent through the Solutions By Text system.
/// </summary>
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