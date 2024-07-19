using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response from the "Schedule Template Message" API.
    /// This class contains the response data, app code, message, and an error flag.
    /// </summary>
    public class ScheduleTemplateMessageResponse
    {
        /// <summary>
        /// The data returned in the response.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}