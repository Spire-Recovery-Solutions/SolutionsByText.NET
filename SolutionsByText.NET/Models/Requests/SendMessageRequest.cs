using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests;

public class SendMessageRequest
{
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("messageType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MessageType MessageType { get; set; }

    [JsonPropertyName("subscribers")]
    public List<Subscriber> Subscribers { get; set; }
}

public class Subscriber
{
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }
}

public enum MessageType
{
    BroadcastMessage,
    Unicast,
    Multicast
}