using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Enums
{
    /// <summary>
    /// Defines the types of Brand VBT inbound messages as specified by the API.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<BrandVBTInboundMessages>))]
    public enum BrandVBTInboundMessages
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
        /// A two-way message type.
        /// </summary>
        TwoWay
    }
}