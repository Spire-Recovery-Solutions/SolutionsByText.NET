using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Enums
{
    /// <summary>
    /// Defines the types of inbound messages that can be processed by the Solutions By Text system.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<InboundMessageType>))]
    public enum InboundMessageType
    {
        /// <summary>
        /// A message type indicating a stop request.
        /// </summary>
        Stop,

        /// <summary>
        /// A message type indicating a stop-all request.
        /// </summary>
        Stopall,

        /// <summary>
        /// A message type indicating a help request.
        /// </summary>
        Help,

        /// <summary>
        /// A message type indicating a keyword message.
        /// </summary>
        Keyword,

        /// <summary>
        /// A two-way message type.
        /// </summary>
        Twoway
    }
}