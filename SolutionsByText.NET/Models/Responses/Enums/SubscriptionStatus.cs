using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Enums
{
    /// <summary>
    /// Defines the possible statuses of a subscriber's subscription.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionStatus
    {
        /// <summary>
        /// The subscriber is active and can receive messages.
        /// </summary>
        Active,

        /// <summary>
        /// The subscriber is inactive and cannot receive messages.
        /// </summary>
        Inactive,

        /// <summary>
        /// The subscriber is not found in the system.
        /// </summary>
        NotFound
    }
}
