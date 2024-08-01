using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Messages
{
    /// <summary>
    /// Represents the response received after scheduling a message.
    /// </summary>
    public class ScheduleMessageResponse : ApiResponse<string>
    {
    }
}
