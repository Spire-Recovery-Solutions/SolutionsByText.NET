using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Enums
{
    /// <summary>
    /// Defines the types of messages that can be sent through the Solutions By Text system.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MessageType>))]
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
}
