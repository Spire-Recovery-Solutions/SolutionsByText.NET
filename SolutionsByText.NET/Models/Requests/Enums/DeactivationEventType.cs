using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Enums
{
    /// <summary>
    /// Defines the types of events that can trigger a deactivation report.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<DeactivationEventType>))]
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
}
