using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Enums
{
    /// <summary>
    /// Defines the types of verification that can be used for subscriber opt-in.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VerificationType
    {
        /// <summary>
        /// Verification using a PIN sent to the subscriber.
        /// </summary>
        Pin,

        /// <summary>
        /// Verification using a keyword response from the subscriber.
        /// </summary>
        ReservedWord,

        /// <summary>
        /// Opt-in without explicit verification (may be subject to regulatory restrictions).
        /// </summary>
        SilentOptin,

        /// <summary>
        /// Standard opt-in process.
        /// </summary>
        Optin
    }
}
