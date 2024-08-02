using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Enums
{
    /// <summary>
    /// Defines the types of outbound messages that can be processed by the Solutions By Text system.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<OutboundMessageType>))]
    public enum OutboundMessageType
    {
        /// <summary>
        /// A two-way message type.
        /// </summary>
        Twoway,

        /// <summary>
        /// A message type used for opt-in responses.
        /// </summary>
        OptInResponse,

        /// <summary>
        /// A message type used for keyword responses.
        /// </summary>
        KeywordResponse,

        /// <summary>
        /// An automatic response message type.
        /// </summary>
        AutoResponse,

        /// <summary>
        /// A broadcast message type.
        /// </summary>
        Broadcast,

        /// <summary>
        /// A scheduled broadcast message type.
        /// </summary>
        ScheduledBroadcast,

        /// <summary>
        /// A response message indicating a stop request.
        /// </summary>
        StopResponse,

        /// <summary>
        /// A response message indicating a help request.
        /// </summary>
        HelpResponse,

        /// <summary>
        /// A response message indicating a stop-all request.
        /// </summary>
        StopAllResponse,

        /// <summary>
        /// A broadcast message type indicating device delivery.
        /// </summary>
        BroadcastDeviceDelivery,

        /// <summary>
        /// A notification message type.
        /// </summary>
        Notification,

        /// <summary>
        /// A VBT message type.
        /// </summary>
        Vbt,

        /// <summary>
        /// A multicast message type.
        /// </summary>
        Multicast,

        /// <summary>
        /// A deactivation message type.
        /// </summary>
        Deact,

        /// <summary>
        /// A message sent to a single subscriber.
        /// </summary>
        Unicast
    }
}