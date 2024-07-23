using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Enums
{
   
    /// <summary>
    /// Defines the possible statuses of a message.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageStatus
    {
        /// <summary>
        /// The message has been queued for sending.
        /// </summary>
        Queued,

        /// <summary>
        /// The message has been sent to the carrier.
        /// </summary>
        Sent,

        /// <summary>
        /// The message has been delivered to the recipient's device.
        /// </summary>
        Delivered,

        /// <summary>
        /// The message failed to be delivered.
        /// </summary>
        Failed
    }
}
