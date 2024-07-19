using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response received after scheduling a message.
    /// </summary>
    public class ScheduleMessageResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the scheduled message.
        /// </summary>
        [JsonPropertyName("scheduleId")]
        public string ScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the status of the scheduled message.
        /// </summary>
        [JsonPropertyName("status")]
        public ScheduleStatus Status { get; set; }
    }
}
