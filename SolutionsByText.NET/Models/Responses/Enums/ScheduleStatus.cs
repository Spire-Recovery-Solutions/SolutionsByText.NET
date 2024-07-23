using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Enums
{
    /// <summary>
    /// Defines the possible statuses of a scheduled message.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ScheduleStatus
    {
        /// <summary>
        /// The message has been successfully scheduled.
        /// </summary>
        Scheduled,

        /// <summary>
        /// The scheduling of the message failed.
        /// </summary>
        Failed
    }
}
