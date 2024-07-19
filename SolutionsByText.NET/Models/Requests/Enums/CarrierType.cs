using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Enums
{

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
}
