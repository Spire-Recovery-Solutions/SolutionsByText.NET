using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Enums
{
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
}
