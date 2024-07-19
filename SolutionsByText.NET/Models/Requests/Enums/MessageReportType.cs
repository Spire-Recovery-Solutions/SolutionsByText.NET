using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Enums
{
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
}
