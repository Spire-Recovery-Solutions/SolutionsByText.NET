using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Messages
{
    /// <summary>
    /// Represents the data returned when scheduling a message.
    /// </summary>
    public class ScheduleMessageData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the scheduled message.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }

    /// <summary>
    /// Represents the response received after scheduling a message.
    /// </summary>
    public class ScheduleMessageResponse : ApiResponse<ScheduleMessageData>
    {
    }
}
